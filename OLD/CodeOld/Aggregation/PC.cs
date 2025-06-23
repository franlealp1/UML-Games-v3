namespace Aggregation
{
    public class PC
    {


        private string _code;
        public PC (string code){
            this._code = code;
        }
        public string Code
        {
            get
            {
                return _code;
            }
            set
            {
                _code = value;
            }
        }
    }



}