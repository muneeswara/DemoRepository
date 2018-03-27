using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EncriptAndDecript
{
    class Program
    {
        static void Main(string[] args)
        {  
            string descriptstring = Program.Decryption("AEHFFipxMqliNn0MFNR0oa82J5uAgpF5Ga/epYcrQPdDSLIDk3FszmkAxK1y3esmFQXexJ/g/y/LMOmUYYsdx5GFop6IA8jlrdBl/TgCtMNpk8oRiIZ6Q1DK8h6LOszHiNudvIKJIydRAWrmHnIvzFetDonB0gVV2CIo88T/R6+is9Pj7841zBVivhXFnxbg/1jGdHQidSCYLx8pexm6EljDlmj2h2YN2kIZfSmIy3ItXqua2zLKX/7tBkC4SsphMeWWaf6c4PxYNeO+dJFnRLNxxuLOZxfSh0/ZZyXeBvbHTPIHoipqJDE8ZbELKMRaN+bTC8q0Pm+qPogUDZ/Ayq0=");
            //  GenerateRsa("C://", "C://", 1024);
            string encript = Program.Encryption("Data Source=ADMIN-B19C3BADF");
        }


        public static string Encryption(string strText)
        {
            var publicKey = "<RSAKeyValue><Modulus>AImnLztup6FZc7K0N+if4tesx7n++m1czHlJP2RX23e/Uo0Ycqn1J17HAEwsdZO2oGgpx0HbuA4VdB4316eEmY0WxQLVTb8qZaU7i0OBYM1LtrYP3uhys8F84lmbKWXZuIkQDLuNDnlIMh1d11WSyneOjcF67t3T9QjU1gdrmnLnnGP6/LPYk8RRRiR6Fy89K9Mk6oFGmbcmo4HNHbxfy2YudonBzy7KreLljXY+vEuMk75Wfv24EoP7JsjNMM5Zr+fCxzZIukrv+sUtPyqWKI22MB4Y3rLiOYXzrIJl7uo13G/ja08CahIojGo4k+kE01TufOP6r9c4nOt90kdZAbM=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
    
            var testData = Encoding.UTF8.GetBytes(strText);

            using (var rsa = new RSACryptoServiceProvider(4096))
            {
                try
                {
                    // client encrypting data with public key issued by server                    
                    rsa.FromXmlString(publicKey.ToString());

                    var encryptedData = rsa.Encrypt(testData, true);

                    var base64Encrypted = Convert.ToBase64String(encryptedData);

                    return base64Encrypted;
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }

        
        }

        //public static string Decryption(string strText)
        //{
        //    var privateKey = "<RSAKeyValue><Modulus>AImnLztup6FZc7K0N+if4tesx7n++m1czHlJP2RX23e/Uo0Ycqn1J17HAEwsdZO2oGgpx0HbuA4VdB4316eEmY0WxQLVTb8qZaU7i0OBYM1LtrYP3uhys8F84lmbKWXZuIkQDLuNDnlIMh1d11WSyneOjcF67t3T9QjU1gdrmnLnnGP6/LPYk8RRRiR6Fy89K9Mk6oFGmbcmo4HNHbxfy2YudonBzy7KreLljXY+vEuMk75Wfv24EoP7JsjNMM5Zr+fCxzZIukrv+sUtPyqWKI22MB4Y3rLiOYXzrIJl7uo13G/ja08CahIojGo4k+kE01TufOP6r9c4nOt90kdZAbM=</Modulus><Exponent>AQAB</Exponent><P>AMEDidnggHI35ga3Dv7mkoisPDympOjcnRTXY1QSfaYZ6nhJy8Us03SAj82AsWOAAfMzk7+P7NQ/IoS1tff8Yr81bm1IMCU31m2FG75YEfw5+Bc28lN7jLyzknReZ615qU2/npilBpLrQ/IhjwtBbAdsnXrPCqSWiwacI4BglkCv</P><Q>ALaSyI4erf12t41US56NfZutSdgsBCr6bhHPLE5r0IKKRKoVKHgHwSouXfzZtaPBdIHMZUtSVrtCVS9X/ZdfHm2qpWlzxq0S8FBVTNo20VlBIeJen9YDBSeBw2abYLnH6fMzFLxHsNkNTvZy6I1bzkeOsW40AY0QCXFD4wIPI+g9</Q><DP>SXN7Rjq1JsI2+182ibJdGT3SPpJ8N1GdRY0h86CFyGwcWmJa9VI1tiQmlWHgH6lbFJ4QH9o5mhvcmvw7n3+gZHuE5nmOONui8lKxWCJT1dSJoOv8E+D0kesUVMyIT+/4ieneBODoO4jkdoRm1zWyUrD2zQF1X2Uayw0oRXZ8N2k=</DP><DQ>ALJd5vgJ+xvkjuDRWOt2+h9MhhdesVe3wC9AAt4+sL/IC9tKvnW9xbbLA+HSZIWuq39fzBpxP/DElmqhgUwQjq6/h8jlZlWSahthqqqJ4a9cVZlNrsQrwS5etSMaa741FFgYMIrdU2ZKfTmC+7WW2onIW4n53wYMg90XYMGTPxZV</DQ><InverseQ>G7CYVBmqzfzOH3hMLOA5AqM/cblUYdQKy/oerCQSupcOuI/2qn8yADQvpy+53w2oPbL/TJDfh1BNsleSpTALGdr7exvZpNvIogi0o2U2Hw1hjK5coGnCH3sVVFYQpv28zJdi14eX+5Hw2TNi1LhGEH6apM+SrcSKZrOX0h6lWWM=</InverseQ><D>VnTE+6UScArI2jLK8raJOUDx6OY2z717R6ozwIhV9a4a4Te7vPeXFLYUf8NkzbPkp8eluL2RqnbbCae1MSfdcXodnxvtyuWMFe2CGJIIBKlLRqpNLN3t/Na9K96Cb9ABUUTdWmbL8mzf3QX1m2+o7tKAQkc+A+F+g196VgrFZOkbsHfzfk1mgKLud00HngI4MbELMLMLRKi/EMxava9B9GqzqHaY+vg9MDyrNK+Uq5MdGB+GL0BMkKWSx+TfPEy0b3z22TzcZE2CT0nYAu6cF5I5xiIlaYgTLaER26ZlcAtBca1kQbQsSFFuJ3Ef5Ih7+/Z4YMwqQc623a7AXQMN0Q==</D></RSAKeyValue>";

       //    var testData = Encoding.UTF8.GetBytes(strText);

       //    using (var rsa = new RSACryptoServiceProvider(2048))
       //    {
       //        try
       //        {
       //            var base64Encrypted = strText;

       //            // server decrypting data with private key                    
       //            rsa.FromXmlString(privateKey);

       //            var resultBytes = Convert.FromBase64String(base64Encrypted);
       //            var decryptedBytes = rsa.Decrypt(resultBytes, true);
       //            var decryptedData = Encoding.UTF8.GetString(decryptedBytes);
       //            return decryptedData.ToString();
       //        }
       //        finally
       //        {
       //            rsa.PersistKeyInCsp = false;
       //        }
       //    }
       //}

       public static string Decryption(string strText)
        {
            var privateKey = "<RSAKeyValue><Modulus>21wEnTU+mcD2w0Lfo1Gv4rtcSWsQJQTNa6gio05AOkV/Er9w3Y13Ddo5wGtjJ19402S71HUeN0vbKILLJdRSES5MHSdJPSVrOqdrll/vLXxDxWs/U0UT1c8u6k/Ogx9hTtZxYwoeYqdhDblof3E75d9n2F0Zvf6iTb4cI7j6fMs=</Modulus><Exponent>AQAB</Exponent><P>/aULPE6jd5IkwtWXmReyMUhmI/nfwfkQSyl7tsg2PKdpcxk4mpPZUdEQhHQLvE84w2DhTyYkPHCtq/mMKE3MHw==</P><Q>3WV46X9Arg2l9cxb67KVlNVXyCqc/w+LWt/tbhLJvV2xCF/0rWKPsBJ9MC6cquaqNPxWWEav8RAVbmmGrJt51Q==</Q><DP>8TuZFgBMpBoQcGUoS2goB4st6aVq1FcG0hVgHhUI0GMAfYFNPmbDV3cY2IBt8Oj/uYJYhyhlaj5YTqmGTYbATQ==</DP><DQ>FIoVbZQgrAUYIHWVEYi/187zFd7eMct/Yi7kGBImJStMATrluDAspGkStCWe4zwDDmdam1XzfKnBUzz3AYxrAQ==</DQ><InverseQ>QPU3Tmt8nznSgYZ+5jUo9E0SfjiTu435ihANiHqqjasaUNvOHKumqzuBZ8NRtkUhS6dsOEb8A2ODvy7KswUxyA==</InverseQ><D>cgoRoAUpSVfHMdYXW9nA3dfX75dIamZnwPtFHq80ttagbIe4ToYYCcyUz5NElhiNQSESgS5uCgNWqWXt5PnPu4XmCXx6utco1UVH8HGLahzbAnSy6Cj3iUIQ7Gj+9gQ7PkC434HTtHazmxVgIR5l56ZjoQ8yGNCPZnsdYEmhJWk=</D></RSAKeyValue>";

            var testData = Encoding.UTF8.GetBytes(strText);

            using (var rsa = new RSACryptoServiceProvider(4096))
            {
                try
                {
                    var base64Encrypted = strText;

                    // server decrypting data with private key                    
                    rsa.FromXmlString(privateKey);

                    var resultBytes = Convert.FromBase64String(base64Encrypted);
                    var decryptedBytes = rsa.Decrypt(resultBytes, true);
                    var decryptedData = Encoding.UTF8.GetString(decryptedBytes);
                    return decryptedData.ToString();
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
        }

    }

   

}
