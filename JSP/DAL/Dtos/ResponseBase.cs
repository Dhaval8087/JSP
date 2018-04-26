using System.Collections.Generic;

namespace DAL.Dtos
{
    public class ResponseBase
    {
        public bool ResultSuccess { get; set; }
        private List<ResultMessage> resultMessages;
        public ResponseBase()
        {
            resultMessages = new List<ResultMessage>();
        }
        public List<ResultMessage> ResultMessages
        {
            get
            {
                return resultMessages;
            }
            set
            {
                if (value != null && value.Count > 0)
                {
                    value.ForEach(msg =>
                    {
                        msg.Message = msg.Message.ToString();
                    });
                }

                resultMessages = value;
            }
        }
    }

    public class ResultMessage
    {
        public string Message { get; set; }
    }
}
