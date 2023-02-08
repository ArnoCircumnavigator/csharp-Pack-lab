using Lab_DDD1_Domain.Contexts;
using Lab_DDD1_Domain.CoreFramework;
using Lab_DDD1_Domain.Entities;
using Lab_DDD1_Domain.Ioc;
using Lab_DDD1_Domain.Repositories;
using Lab_DDD1_Domain.Services;
using Lab_DDD1_Infra.Persistence;
using Lab_DDD1_Infra.PersistenceModel;
using System.IO.Pipes;
using Unity;
using Unity.Lifetime;

namespace Lab_DDD1_SetUp
{
    internal class Program
    {
        private static IBookRepository bookRepository = null;
        private static ILibraryAccountRepository libraryAccountRepository = null;
        private static IBorrowInfoRepository borrowInfoRepository = null;
        private static IBookStoreInfoRepository bookStoreInfoRepository = null;
        private static ILibraryService libraryService = null;


        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            InitializeFramework();

            BorrowReturnBookExample();

            WaitToExit();
        }

        private static void InitializeFramework()
        {
            IUnityContainer container = new UnityContainer();
            UnityContainerHolder.UnityContainer = container;//静态，只是为了永久保存该对对象

            InstanceLocator.SetLocator(new InstanceLocatoerBasedUnityContainer());

            container.RegisterType<IUnitOfWork, UnitOfWork>(new ContainerControlledLifetimeManager());
            container.RegisterType<IEventPublisher, EventPublisher>(new ContainerControlledLifetimeManager());


            //服务
            container.RegisterType<ILibraryService, LibraryService>(new ContainerControlledLifetimeManager());
            //仓库
            container.RegisterType<ILibraryAccountRepository, LibraryAccountRepository>(new ContainerControlledLifetimeManager());
            container.RegisterType<IBookRepository, BookRepository>(new ContainerControlledLifetimeManager());
            container.RegisterType<IBorrowInfoRepository, BorrowInfoRepository>(new ContainerControlledLifetimeManager());
            container.RegisterType<IBookStoreInfoRepository, BookStoreInfoRepository>(new ContainerControlledLifetimeManager());

            DomainInitializer.Current.InitializeDomain(typeof(Book).Assembly);
            DomainInitializer.Current.ResolveDomainEvents(typeof(Book).Assembly);

            bookRepository = DependencyResolver.Resolve<IBookRepository>();
            libraryAccountRepository = DependencyResolver.Resolve<ILibraryAccountRepository>();
            borrowInfoRepository = DependencyResolver.Resolve<IBorrowInfoRepository>();
            bookStoreInfoRepository = DependencyResolver.Resolve<IBookStoreInfoRepository>();
            libraryService = DependencyResolver.Resolve<ILibraryService>();
        }

        private static void BorrowReturnBookExample()
        {
            PrintDescriptionBeforeExample();

            //创建2本书
            var book1 = new Book { BookName = "C#高级编程", Author = "Jhon Smith", ISBN = "56-YAQ-23452", Publisher = "清华大学出版社", Description = "A very good book." };
            var book2 = new Book { BookName = "JQuery In Action", Author = "Jhon Smith", ISBN = "09-BEH-23452", Publisher = "人民邮电出版社", Description = "A very good book." };
            bookRepository.Add(book1);
            bookRepository.Add(book2);

            //创建一个图书馆用户帐号，用户凭帐号借书
            var libraryAccount = new LibraryAccount(GenerateAccountNumber(10)) { OwnerName = "汤雪华", IsLocked = false };
            libraryAccountRepository.Add(libraryAccount);
            PrintAccountInfo(libraryAccount);

            //创建并启动图书入库场景
            PrintDescriptionBeforeStoreBookContext(book1, book2);
            new StoreBookContext(libraryService, book1).Interaction(2, "4F-S-0001");
            new StoreBookContext(libraryService, book2).Interaction(3, "4F-N-0002");
            PrintBookCount(book1, book2);

            //创建并启动借书场景
            PrintDescriptionBeforeBorrowBookContext(libraryAccount, book1, book2);
            new BorrowBooksContext(libraryAccount, new List<Book> { book1, book2 }).Interaction();
            PrintBorrowInfo(libraryAccount);
            PrintBookCount(book1, book2);

            //创建并启动还书场景
            PrintDescriptionBeforeReturnBookContext(libraryAccount, book1);
            new ReturnBooksContext(libraryAccount, new List<Book> { book1 }).Interaction();
            PrintBorrowInfo(libraryAccount);
            PrintBookCount(book1, book2);
        }

        #region Helper Methods
        private static void PrintDescriptionBeforeExample()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("图书借阅系统领域建模示例");
            Console.WriteLine("-----------------------------------------------------------------------");
        }
        private static void PrintDescriptionBeforeStoreBookContext(Book book1, Book book2)
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("图书入库场景：");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("将两本书入库到图书馆：");
            Console.Write(string.Format("【{0}】", book1.BookName));
            Console.Write(string.Format("【{0}】", book2.BookName));
        }
        private static void PrintDescriptionBeforeBorrowBookContext(LibraryAccount libraryAccount, Book book1, Book book2)
        {
            Console.WriteLine(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("借书场景：");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(string.Format("帐号{0}借两本书：", libraryAccount.Number));
            Console.Write(string.Format("【{0}】", book1.BookName));
            Console.Write(string.Format("【{0}】", book2.BookName));
        }
        private static void PrintDescriptionBeforeReturnBookContext(LibraryAccount libraryAccount, Book book1)
        {
            Console.WriteLine(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("还书场景：");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(string.Format("帐号{0}还一本书：", libraryAccount.Number));
            Console.Write(book1.BookName);
        }
        private static void PrintAccountInfo(LibraryAccount libraryAccount)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("");
            Console.WriteLine(string.Format("创建了一个图书馆用户账号：{0}，账号拥有者：{1}", libraryAccount.Number, libraryAccount.OwnerName));
        }
        private static void PrintBorrowInfo(LibraryAccount libraryAccount)
        {
            Console.WriteLine("");
            Console.Write(string.Format("帐号{0}当前已借的书本：", libraryAccount.Number));
            Console.ForegroundColor = ConsoleColor.White;
            borrowInfoRepository.FindNotReturnedBorrowInfos(libraryAccount.Id, out var borrowedInfos);
            foreach (var borrowedInfo in borrowedInfos)
            {
                Console.Write("【{0}】", borrowedInfo.Book.BookName);
            }
        }
        private static void PrintBookCount(Book book1, Book book2)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("");
            Console.Write("书本数量信息：");
            libraryService.GetBookStoreInfo(book1.Id, out var book1StoreInfo);
            libraryService.GetBookStoreInfo(book2.Id, out var book2StoreInfo);
            Console.Write(string.Format("【{0}】：{1}本；", book1.BookName, book1StoreInfo?.Count));
            Console.Write(string.Format("【{0}】：{1}本；", book2.BookName, book2StoreInfo?.Count));
        }
        private static int rep = 0;
        private static string GenerateAccountNumber(int codeCount)
        {
            string str = string.Empty;
            long num2 = DateTime.Now.Ticks + rep;
            rep++;
            Random random = new Random(((int)(((ulong)num2) & 0xffffffffL)) | ((int)(num2 >> rep)));
            for (int i = 0; i < codeCount; i++)
            {
                int num = random.Next();
                str = str + ((char)(0x30 + ((ushort)(num % 10)))).ToString();
            }
            return str;
        }
        #endregion
        private static void WaitToExit()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("按回车键退出...");
            Console.Read();
        }
    }
}