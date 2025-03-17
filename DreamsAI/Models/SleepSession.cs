namespace DreamsAI.Models
{
    public class SleepSession
    {
		public int Id { get; internal set; }

		public DateTime BedTime { get; internal set; }
        public DateTime WakeUpTime { get; internal set; }
        public string? UserId { get; internal set; }
        public virtual User? User { get; set; }
		public int SleepQuality { get; internal set; }
		public double Duration { get; internal set; }
	}
}