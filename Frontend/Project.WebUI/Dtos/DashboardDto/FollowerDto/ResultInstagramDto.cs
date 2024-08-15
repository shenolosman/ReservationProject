namespace Project.WebUI.Dtos.DashboardDto.FollowerDto
{
    public class ResultInstagramDto
    {
        public DataDto Data { get; set; }

        public class DataDto
        {
            public int follower_count { get; set; }
            public int following_count { get; set; }
        }

    }
}
