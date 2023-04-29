namespace BookingApp.Model.DTO
{
    public class HotelsSearchQuery
    {
        public HotelsSearchQuery(string searchType, string searchValue, string additionalSearchType, string additionalSearchValue, bool connection)
        {
            SearchType = searchType;
            SearchValue = searchValue;
            AdditionalSearchType = additionalSearchType;
            AdditionalSearchValue = additionalSearchValue;
            Connection = connection;
        }

        public string SearchType { get; set; }
        public string SearchValue { get; set; }
        public string AdditionalSearchType { get; set; }
        public string AdditionalSearchValue { get; set; }
        public bool Connection { get; set; }
    }
}
