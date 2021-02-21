using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace hotelbooking
{

    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        bool addUser(String name, String email, String mobileno, String password);

        [OperationContract]
        bool addHotel(String hotelname, String address, String city, String rating, String rent);

        [OperationContract]
        bool checkUser(String email, String password);

        [OperationContract]
        List<hotel> getHotels();
    }
    [DataContract]
    public class hotel
    {
        [DataMember]
        public string hotelname
        {
            get;
            set;
        }

        [DataMember]
        public string address
        {
            get;
            set;
        }

        [DataMember]
        public string city
        {
            get;
            set;
        }

        [DataMember]
        public string rating
        {
            get;
            set;
        }

        

        [DataMember]
        public string rent
        {
            get;
            set;
        }

       
    }


}
