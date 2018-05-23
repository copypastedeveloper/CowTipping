using System;
using System.Threading;
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
                var handler = new TimeToTipACowHandler();
                handler.Handle(message);
            }, cfg => cfg.WithDurable());
        }

        public void Stop() { _bus.Dispose(); }
    }
}