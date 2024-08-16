namespace Project.WebUI.Dtos.DashboardDto.FollowerDto
{
    public class ResultTwitterDto
    {
        public Legacy legacy { get; set; }

        public class Legacy
        {
            public int followers_count { get; set; }
            public int friends_count { get; set; }
        }
    }
}
