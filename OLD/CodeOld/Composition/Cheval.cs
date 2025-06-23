namespace Composition
{
    public class Cheval
    {
        private int _id;
        public Cheval (int id){
            this._id = id;
        }
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
    }



}