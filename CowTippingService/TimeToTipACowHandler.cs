using CowTipping.Messages;

namespace CowTippingService
{
    public class TimeToTipACowHandler
    {
        public void Handle(TimeToTipACow message)
        {
            var db = new AppDbContext();
            db.TippedCows.Add(new TippedCow {DateTipped = message.EventTime, Name = message.NameOfCow});
            db.SaveChanges();
        }
    }
}