namespace AssistenciaTecnica.WebAPI.Firebase
{
    //https://www.c-sharpcorner.com/article/creating-c-sharp-wrapper-over-firebase-api-for-basic-crud/
    public class Tutorial
    {
        public void Metodo()
        {

            // URL banco de dados Firebase  
            FirebaseDB firebaseDB = new FirebaseDB("https://assistenciatecnica-f6d54.firebaseio.com/");

            // Referenciando Node  "Teams"  
            FirebaseDB firebaseDBTeams = firebaseDB.Node("Teams");

            FirebaseResponse getResponse = firebaseDBTeams.Get();

            // if(getResponse.Success) {
            // return getResponse.JSONContent;
            // } 

            var data = @"{  
                            'Team-Awesome': {  
                                'Members': {  
                                    'M1': {  
                                        'City': 'Hyderabad',  
                                        'Name': 'Ashish'  
                                        },  
                                    'M2': {  
                                        'City': 'Cyberabad',  
                                        'Name': 'Vivek'  
                                        },  
                                    'M3': {  
                                        'City': 'Secunderabad',  
                                        'Name': 'Pradeep'  
                                        }  
                                   }  
                               }  
                          }";

            //PUT Request;  
            FirebaseResponse putResponse = firebaseDBTeams.Put(data);  
            // WriteLine(putResponse.Success);  

            //POST Request;  
            FirebaseResponse postResponse = firebaseDBTeams.Post(data);  
            // WriteLine(postResponse.Success);  

            //PATCH Request;  
            FirebaseResponse patchResponse = firebaseDBTeams  
                // Use of NodePath to refer path lnager than a single Node  
                .NodePath("Team-Awesome/Members/M1")  
                .Patch("{\"Designation\":\"CRM Consultant\"}");  
            // WriteLine(patchResponse.Success);  

            //DELETE Request;  
            FirebaseResponse deleteResponse = firebaseDBTeams.Delete();
            // WriteLine(deleteResponse.Success);  

        }
    }
}