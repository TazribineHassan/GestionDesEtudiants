using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    
    class ClientHandler : myThread
    {
        private ConnectivityHandler connection;
        private Socket socket;

        public ClientHandler(ConnectivityHandler connection, Socket socket)
        {
            this.connection = connection;
            this.socket = socket;
        }

        public override void run()
        {
            int size = 1024;
            byte[] buffer = new byte[size];
            while (true)
            {
                try
                {
                    buffer = new byte[1024];
                    size = socket.Receive(buffer);
                    Console.WriteLine(size);
                    Array.Resize(ref buffer, size);
                    Request request = (Request)SerializeDeserializeObject.Deserialize(buffer);

                    Object answer = null;
                    int nbRowsAffected = 0;
                    string CNE;
                    Branch branch;
                    switch (request.Type)
                    {
                        case RequestType.AddStudent:
                            Student student = (Student)request.Data;
                            Console.WriteLine("Adding student ...");
                            nbRowsAffected = connection.addStudent(student);
                            if (nbRowsAffected > 0)
                                answer = true;
                            else
                                answer = false;
                            break;

                        case RequestType.UpdateStudent:
                            Student data = (Student)request.Data;
                            Console.WriteLine("Updating student ...");
                            nbRowsAffected = connection.updateStudent(data);
                            if (nbRowsAffected > 0)
                                answer = true;
                            else
                                answer = false;
                            break;

                        case RequestType.GetOneStudnet:
                            Console.WriteLine("getting one Student");
                            CNE = (string)request.Data;
                            answer = connection.getStudent(CNE);
                            break;

                        case RequestType.GetAllStudnets:
                            Console.WriteLine("getting all students");
                            answer = connection.getAllStudents();
                            break;

                        case RequestType.GetStudentByBranch:
                            Console.WriteLine("getting all students grouping by branch");
                            answer = connection.getStudentsByBranch();
                            break;

                        case RequestType.DeleteStudent:
                            Console.WriteLine("Deleting the student");
                            CNE = (string)request.Data; 
                            nbRowsAffected = connection.deleteStudent(CNE);
                            if (nbRowsAffected > 0)
                                answer = true;
                            else
                                answer = false;
                            break;

                        case RequestType.AddBranch:
                            Console.WriteLine("Adding a branch");
                            branch = (Branch)request.Data;
                            nbRowsAffected = connection.addBranch(branch);
                            if (nbRowsAffected > 0)
                                answer = true;
                            else
                                answer = false;
                            break;

                        case RequestType.UpdateBranch:
                            Console.WriteLine("Updating a branch");
                            branch = (Branch)request.Data;
                            nbRowsAffected = connection.updateBranch(branch);
                            if (nbRowsAffected > 0)
                                answer = true;
                            else
                                answer = false;
                            break;

                        case RequestType.GetAllBranches:
                            Console.WriteLine("Getting all branches");
                            answer = connection.getAllBranchs();
                            break;

                        case RequestType.DeleteBranch:
                            Console.WriteLine("Deleting the branch");
                            int ID = (int)request.Data;
                            nbRowsAffected = connection.deleteBranch(ID);
                            if (nbRowsAffected > 0)
                                answer = true;
                            else
                                answer = false;
                            break;

                        case RequestType.GetStatics:
                            Console.WriteLine("Getting the statistics");
                            answer = connection.getStatistics();
                            break;
                        case RequestType.CheckUser:
                            Console.WriteLine("Getting the user");
                            User user = request.Data as User;
                            answer = connection.CheckUser(user);
                       
                            break;
                        case RequestType.UpdateUser:
                            Console.WriteLine("Updating the user");
                            User userUpadte = request.Data as User;
                            nbRowsAffected = connection.UpdateUser(userUpadte);
                            if (nbRowsAffected > 0) answer = true;
                            else answer = false;
                            break;
                    }

                    byte[] bufferAnswer = SerializeDeserializeObject.Serialize(answer);
                    
                    socket.Send(bufferAnswer);

                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                    /*socket.Close();
                    socket.Dispose();*/
                    break;
                }

            }
        }
    }

    public abstract class myThread
    {
        private Thread _thread;

        protected myThread()
        {
            _thread = new Thread(new ThreadStart(this.run));
        }

        // Thread methods / properties
        public void Start() => _thread.Start();
        public void Join() => _thread.Join();
        public bool IsAlive => _thread.IsAlive;

        // Override in base class
        public abstract void run();
    }

}
