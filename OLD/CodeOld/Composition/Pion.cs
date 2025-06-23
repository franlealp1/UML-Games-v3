namespace Composition
{
    public class Pion
    {
        private int _id;
        public Pion (int id){
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