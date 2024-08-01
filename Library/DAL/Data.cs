namespace Library.DAL
{
    public class Data
    {
        //מחרוזת חיבור למס הנתונים
        string connectionString = "" + "server=REUVEN\\SQLEXPRESS ;" + "initial catalog=Libery ;" + "user id=sa ;" + "password=1234 ;" + "TrustServerCertificate=Yes";
        //יצירה של משתנה לייר בתוך הבנאי
        private Data()
        {
            Layer = new DataLayer(connectionString);
        }
        // משתנה סטטי לשמירה של מופע יחיד של המחלקה
        static Data GetData;
        //מאפיין 
        public static DataLayer Get
        {
            get
            {
                //יצירת מופע חדש של המחלקה אם לא קיים
                if (GetData == null)
                {
                    //צור קלאס דאטא חדש
                    GetData = new Data();
                }
                // תחזיר לי את ה
                return GetData.Layer;

            }
        }
        //יצירת משתנה מסוג דאטהלייר שישמור את הנתונים עם גט וסט
        public DataLayer Layer { get; set; }
    }

}
