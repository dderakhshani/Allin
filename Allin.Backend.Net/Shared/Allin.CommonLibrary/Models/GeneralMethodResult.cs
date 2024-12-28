namespace Allin.Common.Models
{
    //public class GeneralServiceResult<T> : GeneralServiceResult
    //{
    //    public new T? Data { get; set; }

    //    protected override object? _data { get => this.Data; set => this.Data = (T?)value; }
    //}

    //public class GeneralServiceResult
    //{
    //    public bool IsSuccess { get; set; }
    //    public string TraceId { get; set; }
    //    public IEnumerable<ValidationFailure>? Errors { get; set; }

    //    public object? Data
    //    {
    //        get
    //        {
    //            return this._data;
    //        }
    //        set { this._data = value; }
    //    }

    //    protected virtual object? _data { get; set; }


    //    public static GeneralServiceResult Ok()
    //    {
    //        return new GeneralServiceResult()
    //        {
    //            IsSuccess = true,
    //        };
    //    }

    //    public static GeneralServiceResult Ok(object data)
    //    {
    //        return new GeneralServiceResult()
    //        {
    //            IsSuccess = true,
    //            Data = data
    //        };
    //    }

    //    public static GeneralServiceResult<T> Ok<T>(T data)
    //    {
    //        return new GeneralServiceResult<T>()
    //        {
    //            IsSuccess = true,
    //            Data = data
    //        };
    //    }

    //    public static GeneralServiceResult Fail(string traceId, string[] errors)
    //    {
    //        return new GeneralServiceResult()
    //        {
    //            IsSuccess = false,
    //            Errors = errors.Select(msg => new ValidationFailure("", msg)),
    //            TraceId = traceId
    //        };
    //    }

    //    public static GeneralServiceResult<T> Fail<T>(string traceId, string[] errors)
    //    {
    //        return new GeneralServiceResult<T>()
    //        {
    //            IsSuccess = false,
    //            Errors = errors.Select(msg => new ValidationFailure("", msg)),
    //            TraceId = traceId
    //        };
    //    }

    //    public static GeneralServiceResult Fail(IEnumerable<ValidationFailure>? errors = null)
    //    {
    //        return new GeneralServiceResult()
    //        {
    //            IsSuccess = false,
    //            Errors = errors,
    //        };
    //    }
    //}
}
