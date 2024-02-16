namespace MiniCRMCore.Models
{
    public class Mission
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DeadLine { get; set; }
        public int OutDay { get; set; }
        public int FinishProcent { get; set; }
        public int EmployeeId { get; set; }
    }
}
