namespace CRM.Application.Responses
{
    public class BaseResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
        public List<string>? Errors { get; set; }

        public static BaseResponse<PagedList<T>> SuccessResult(IEnumerable<T> data, int currentPage, int pageSize, string? message = null)
        {
            var pagedList = new PagedList<T>(data, currentPage, pageSize);
            return new BaseResponse<PagedList<T>> { Success = true, Data = pagedList, Message = message ?? "Operation completed successfully." };
        }

        public static BaseResponse<T> SuccessResult(T? data, string? message = null)
        {
            return new BaseResponse<T> { Success = true, Data = data, Message = message ?? "Requested data retrieved successfully." };
        }

        public static BaseResponse<T> FailureResult(List<string> errors, string? message = null)
        {
            return new BaseResponse<T> { Success = false, Data = default, Errors = errors, Message = message ?? "Operation failed." };
        }

        public static BaseResponse<T> FailureResult(string error, string? message = null)
        {
            return new BaseResponse<T> { Success = false, Data = default, Errors = [error], Message = message ?? "Operation failed." };
        }

    }

    public class PagedList<T>
    {
        public IEnumerable<T>? Items { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }

        public PagedList(IEnumerable<T> items, int currentPage, int pageSize)
        {
            Items = items;
            CurrentPage = currentPage;
            PageSize = pageSize;
        }
    }

}
