namespace SchoolWeb.Models
{
    public class PersonListViewModel
    {
        public List<Person>? People { get; set; }

        #region Pagination
        public int ItemPerPage { get; set; }
        public int NumberOfPages { get; set; }
        public int CurrentPage { get; set; }
        #endregion
    }
}
