using System;
using System.Threading;
using System.Timers;
using CowTipping.Messages;
using EasyNetQ;

namespace CowTippingService
{
    public class CowTipper
    {
        private IBus _bus;

        public CowTipper(double interval)
        {
            _bus = RabbitHutch.CreateBus("host=localhost");
        }

        public void Start()
        {
            _bus.Subscribe<TimeToTipACow>("CowTipping", message =>
            {
                Thread.Sleep(2000);
                Console.WriteLine($"It is {message.EventTime} and I tipped a cow named {message.NameOfCow}!");
            }, cfg => cfg.WithDurable());
        }
        public void Stop() { _bus.Dispose(); }
    }
}