namespace Project.WebUI.Dtos.DashboardDto.FollowerDto
{
    public class ResultLinkednDto
    {

        public Data data { get; set; }
        public class Data
        {
            public int connections { get; set; }
            public int followers { get; set; }
        }
    }
}
