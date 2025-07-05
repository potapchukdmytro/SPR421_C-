using System.Text.Json;

namespace _12_patterns
{
    public interface IPrototype<T>
        where T : class
    {
        T Clone();
    }

    public class Square : IPrototype<Square>
    {
        private float width;

        public Square()
        {
            width = 0.0f; // Default width
        }

        public Square(float width)
        {
            this.width = width;
        }

        public float GetWidth()
        {
            return width;
        }

        public float GetArea()
        {
            return width * width;
        }

        public Square Clone()
        {
            return new Square(width);
        }
    }

    public class Database
    {
        private static Database? instance = null;
        private string connectionString = "localhost:5432";
        private Database() { }

        public static Database GetInstance()
        {
            if(instance == null)
            {
                instance = new Database();
            }

            return instance;
        }
    }

    // bridge
    interface IDevice
    {
        bool IsEnabled { get; set; }
        void Enable();
        void Disable();
        float GetVolume();
        void SetVolume(float volume);
        int GetChannel();
        void SetChannel(int channel);
    }

    class TV : IDevice
    {
        public bool IsEnabled { get; set; }
        private float volume;
        private int channel = 1;
        public void Enable() => IsEnabled = true;
        public void Disable() => IsEnabled = false;
        public float GetVolume() => volume;
        public void SetVolume(float volume) => this.volume = volume;
        public int GetChannel() => channel;
        public void SetChannel(int channel) => this.channel = channel;
    }
    public class Radio : IDevice
    {
        public bool IsEnabled { get; set; }
        private float volume;
        private int channel = 1;
        public void Enable() => IsEnabled = true;
        public void Disable() => IsEnabled = false;
        public float GetVolume() => volume;
        public void SetVolume(float volume) => this.volume = volume;
        public int GetChannel() => channel;
        public void SetChannel(int channel) => this.channel = channel;
    }


    // decorator
    class Notifier
    {
        public virtual void Notify(string message)
        {
            Console.WriteLine($"Notification: {message}");
        }
    }

    class EmailNotifier : Notifier
    {
        public override void Notify(string message)
        {
            Console.WriteLine($"Email Notification: {message}");
        }
    }

    class SMSNotifier : Notifier
    {
        public override void Notify(string message)
        {
            Console.WriteLine($"SMS Notification: {message}");
        }
    }

    class NotifierDecorator : Notifier
    {
        protected Notifier notifier;
        public NotifierDecorator(Notifier notifier)
        {
            this.notifier = notifier;
        }
        public override void Notify(string message)
        {
            notifier.Notify(message);
        }
    }

    class EmailNotifierDecorator : NotifierDecorator
    {
        public EmailNotifierDecorator(Notifier notifier) : base(notifier) { }
        public override void Notify(string message)
        {
            base.Notify(message);
            Console.WriteLine($"Sending email for: {message}");
        }
    }

    class SMSNotifierDecorator : NotifierDecorator
    {
        public SMSNotifierDecorator(Notifier notifier) : base(notifier) { }
        public override void Notify(string message)
        {
            base.Notify(message);
            Console.WriteLine($"Sending SMS for: {message}");
        }
    }


    class Remote
    {
        private IDevice device;

        public Remote(IDevice device)
        {
            this.device = device;
        }

        public void TogglePower()
        {
            if(device.IsEnabled)
            {
                device.Disable();
            }
            else
            {
                device.Enable();
            }
        }

        public void VolumeDown()
        {
            device.SetVolume(device.GetVolume() - 1);
        }

        public void VolumeUp()
        {
            device.SetVolume(device.GetVolume() + 1);
        }
    }

    class AdvancedRemote : Remote
    {
        private readonly IDevice device;
        private float beforeMuteVolume;

        public AdvancedRemote(IDevice device) 
            : base(device)
        {
            this.device = device;
        }

        public void Mute()
        {
            if(device.IsEnabled)
            {
                beforeMuteVolume = device.GetVolume();
                device.SetVolume(0);
            }
        }

        public void Unmute()
        {
            if(device.IsEnabled)
            {
                device.SetVolume(beforeMuteVolume); // Default volume after unmuting
            }
        }
    }





    // 

    class Request
    { 
        public string Url { get; set; }
        public string Method { get; set; }
        public string Status { get; set; }
    }
    
    abstract class MiddleWare
    {
        protected MiddleWare? next;
        public MiddleWare(MiddleWare next)
        {
            this.next = next;
        }

        public MiddleWare() { }

        public virtual void Execute(Request request)
        {
            if (next != null)
            {
                next.Execute(request);
            }
        }
    }

    class UrlMiddleware : MiddleWare
    {
        public UrlMiddleware(MiddleWare next) : base(next) { }
        public UrlMiddleware() : base() { }
        public override void Execute(Request request)
        {
            if(request.Url != "localhost")
            {
                return;
            }

            Console.WriteLine("Url is correct");

            base.Execute(request);
        }
    }

    class MethodMiddleware : MiddleWare
    {
        public MethodMiddleware(MiddleWare next) : base(next) { }
        public MethodMiddleware() : base() { }
        public override void Execute(Request request)
        {
            if (request.Method != "GET")
            {
                return;
            }

            Console.WriteLine("Correct method");

            base.Execute(request);
        }
    }

    class StatusMiddleware : MiddleWare
    {
        public StatusMiddleware(MiddleWare next) : base(next) { }
        public StatusMiddleware() : base() { }
        public override void Execute(Request request)
        {
            if (request.Status != "200")
            {
                Console.WriteLine($"Error {request.Status}");
                return;
            }

            Console.WriteLine("Ok");

            base.Execute(request);
        }
    }

    // snapshot
    public interface ISnapshot
    {
        string CreateSnapshot();
    }

    public class GameSettings : ISnapshot
    {
        private float screanWidth;
        private float screanHeight;
        private bool vSyncEnabled;

        public string CreateSnapshot()
        {
            return JsonSerializer.Serialize(this);
        }
    }

    public class Game
    {
        private GameSettings settings;

        public void Save()
        {
            string json = settings.CreateSnapshot();
        }
    }




    interface IState
    {
        void Render();
        void Publish();
    }

    class FileState : IState
    {
        public void Publish()
        {
            Console.WriteLine("File saved");
        }

        public void Render()
        {
            Console.WriteLine("Debug render");
        }
    }

    class Document
    {
        private IState state;

        public void Publish()
        {
            state.Publish();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Square square1 = new Square(5.0f);
            Square square2 = square1.Clone();

            //List<int> a = new List<int>();

            //Database db = Database.GetInstance();
            //Database db2 = Database.GetInstance();
            //Database db3 = Database.GetInstance();



            // Bridge
            //TV tv = new TV();
            //Radio radio = new Radio();

            //Remote remoteTV = new Remote(tv);

            //Console.WriteLine(tv.GetVolume());
            //remoteTV.VolumeUp();
            //Console.WriteLine(tv.GetVolume());


            //radio.SetVolume(5.55f);
            //var advancedRemoteRadio = new AdvancedRemote(radio);
            //advancedRemoteRadio.TogglePower();
            //advancedRemoteRadio.Mute();
            //Console.WriteLine(radio.GetVolume());
            //advancedRemoteRadio.Unmute();
            //Console.WriteLine(radio.GetVolume());



            // Decorator
            //Notifier notifier = new Notifier();
            //Notifier emailNotifier = new EmailNotifier();
            //Notifier smsNotifier = new SMSNotifier();

            //Notifier decoratedNotifier = new NotifierDecorator(new EmailNotifierDecorator(new SMSNotifier()));
            //decoratedNotifier.Notify("Test");





            UrlMiddleware urlMiddleware = new UrlMiddleware();
            MethodMiddleware methodMiddleware = new MethodMiddleware(urlMiddleware);
            StatusMiddleware statusMiddleware = new StatusMiddleware(methodMiddleware);

            var request = new Request
            {
                Url = "localhost",
                Method = "GET",
                Status = "300"
            };


            statusMiddleware.Execute(request);
        }
    }
}
