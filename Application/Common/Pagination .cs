namespace Application.Common;

public partial class Pagination
{
    public int currentPage { set; get; } = 1;
    public int pageSize { set; get; } = 10;
    public string keyword { set; get; } = string.Empty;

}
public partial class PaginationWithParent : Pagination
{
    public int currentPage { set; get; } = 1;
    public int pageSize { set; get; } = 10;
    public string keyword { set; get; } = string.Empty;
    public Guid ParentId { set; get; }
}
public partial class PaginationWithKey : Pagination
{
    public int currentPage { set; get; } = 1;
    public int pageSize { set; get; } = 10;
    public string keyword { set; get; } = string.Empty;
    public string Key { set; get; }
}