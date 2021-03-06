using System.Collections.Generic;

namespace UnipPim.Hotel.Desktop.Service.ModelsDTO
{

    public class ResponseResult<T>
    {
        public T Class { get; set; }
        public ResponseResult Response { get; set; }
    }

    public class ResponseResult
    {
        public string Title { get; set; }
        public int Status { get; set; }
        public ResponseErrorMessages errors { get; set; }

        public ResponseResult()
        {
            errors = new ResponseErrorMessages();
        }
    }

    public class ResponseErrorMessages
    {
        public List<string> Messagens { get; set; }

        public ResponseErrorMessages()
        {
            Messagens = new List<string>();
        }
    }
}
