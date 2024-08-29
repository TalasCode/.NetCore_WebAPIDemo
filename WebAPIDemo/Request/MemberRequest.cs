namespace WebAPIDemo.Request
{
    public class MemberRequest
    {
        public string? Name { get; set; }

        public string? Email { get; set; }

        public DateOnly? DateOfBirth { get; set; }

        public string? Gender { get; set; }

        public DateOnly? JoiningDate { get; set; }


        public string? Profession { get; set; }

        public string? Nationality { get; set; }
    }
}
