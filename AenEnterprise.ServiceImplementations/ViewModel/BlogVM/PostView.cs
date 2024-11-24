namespace AenEnterprise.ServiceImplementations.ViewModel.BlogVM
{
    public class PostView
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PublishedDate { get; set; }
        public string CategoryName { get; set; }
        public int CommentCount { get; set; }
    }
}