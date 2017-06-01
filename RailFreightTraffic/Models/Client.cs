using FirebirdSql.Data.FirebirdClient;
using RailFreightTraffic.ViewModels.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailFreightTraffic.Models.App
{
    public class UserClient
    {
        public ConnectionStatus ConnectionStatus { get; private set; }

        public UserData CurrentUser { get; private set; }

        internal static void AddUser(UserData userData)
        {
            FbClient.ExecuteQuery(string.Format("INSERT INTO USERS (NAME, PASS, CH_CARGO, CH_CLIENT, CH_CONTENT, CH_ROUTE, CH_USERS, CH_STATION) VALUES ('{0}','{1}',{2},{3},{4},{5},{6},{7});",
                userData.Логин, userData.Пароль, Convert.ToInt32(userData.Грузы), Convert.ToInt32(userData.Клиенты), Convert.ToInt32(userData.Товары), Convert.ToInt32(userData.Маршруты), Convert.ToInt32(userData.Пользователи), Convert.ToInt32(userData.Станции)));
        }

        internal static void EditUser(UserData userData)
        {
            FbClient.ExecuteQuery(string.Format("UPDATE USERS SET NAME = '{0}', PASS = '{1}', CH_CARGO = {2}, CH_CLIENT = {3}, CH_CONTENT = {4}, CH_ROUTE = {5}, CH_USERS = {6}, CH_STATION = {7} WHERE KEY = {8};", 
                userData.Логин, userData.Пароль, Convert.ToInt32(userData.Грузы), Convert.ToInt32(userData.Клиенты), Convert.ToInt32(userData.Товары), Convert.ToInt32(userData.Маршруты), Convert.ToInt32(userData.Пользователи), Convert.ToInt32(userData.Станции), userData.GetKey()));
        }

        internal static void EditCargo(CargoData cargoData)
        {
            List<ContentsData> contents = LoadContents().ToList();
            List<ClientData> clients = LoadClients().ToList();
            List<RouteData> routes = LoadRoutes().ToList();

            var content = contents.Find(x => x.Наименование == cargoData.Товар);
            var client = clients.Find(x => (x.Имя == cargoData.Клиент.Split(' ')[0] && x.Фамилия == cargoData.Клиент.Split(' ')[1]));
            var route = routes.Find(x => (x.Начальная == cargoData.Маршрут.Split('-')[0] && x.Конечная == cargoData.Маршрут.Split('-')[1]));
            FbClient.ExecuteQuery(string.Format("UPDATE CARGO SET CLIENT = {0}, CONTENT = {1}, ROUTE = '{2}', DATE_OPERATION = '{3}' WHERE KEY = {4};",
                client.GetKey(), content.GetKey(), route.GetKey(), cargoData.Дата, cargoData.GetKey()));
        }

        internal static void AddCargo(CargoData cargoData)
        {
            List<ContentsData> contents = LoadContents().ToList();
            List<ClientData> clients = LoadClients().ToList();
            List<RouteData> routes = LoadRoutes().ToList();

            var content = contents.Find(x => x.Наименование == cargoData.Товар);
            var client = clients.Find(x => (x.Имя == cargoData.Клиент.Split(' ')[0] && x.Фамилия == cargoData.Клиент.Split(' ')[1]));
            var route = routes.Find(x => (x.Начальная == cargoData.Маршрут.Split('-')[0] && x.Конечная == cargoData.Маршрут.Split('-')[1]));

            FbClient.ExecuteQuery(string.Format("INSERT INTO CARGO (CLIENT,CONTENT,ROUTE,DATE_OPERATION) VALUES ({0},{1},{2},'{3}');",
                client.GetKey(), content.GetKey(), route.GetKey(), cargoData.Дата));
        }

        internal static void EditStation(StationData stationData)
        {
            FbClient.ExecuteQuery(string.Format("UPDATE STATION SET NAME = '{0}' WHERE KEY = {1};", stationData.Наименование, stationData.GetKey()));
        }

        internal static void DeleteCargo(CargoData cargoData)
        {
            FbClient.ExecuteQuery(string.Format("DELETE FROM CARGO WHERE KEY = {0};", cargoData.GetKey()));
        }

        internal static void AddStation(StationData stationData)
        {
            FbClient.ExecuteQuery(string.Format("INSERT INTO STATION (NAME) VALUES ('{0}');", stationData.Наименование));
        }

        internal static void DeleteStation(StationData stationData)
        {
            FbClient.ExecuteQuery(string.Format("DELETE FROM STATION WHERE KEY = {0};", stationData.GetKey()));
        }

        internal static void EditRoute(RouteData routeData)
        {
            List<StationData> stations = LoadStations().ToList();

            var startIndex = stations.Find(x => x.Наименование == routeData.Начальная);
            var finishIndex = stations.Find(x => x.Наименование == routeData.Конечная);

            if(startIndex == null)
            {
                AddStation(new StationData()
                {
                    Наименование = routeData.Начальная
                });
                stations = LoadStations().ToList();
                startIndex = stations.Find(x => x.Наименование == routeData.Начальная);
            }

            if (finishIndex == null)
            {
                AddStation(new StationData()
                {
                    Наименование = routeData.Конечная
                });
                stations = LoadStations().ToList();
                finishIndex = stations.Find(x => x.Наименование == routeData.Конечная);
            }

            FbClient.ExecuteQuery(string.Format("UPDATE ROUTE SET START_STATION = {0}, FINISH_STATION = {1}, PRICE = '{2}' WHERE KEY = {3};", 
                startIndex.GetKey(), finishIndex.GetKey(), routeData.Цена, routeData.GetKey()));

        }

        internal static void AddRoute(RouteData routeData)
        {
            List<StationData> stations = LoadStations().ToList();

            var startIndex = stations.Find(x => x.Наименование == routeData.Начальная);
            var finishIndex = stations.Find(x => x.Наименование == routeData.Конечная);

            if (startIndex == null)
            {
                AddStation(new StationData()
                {
                    Наименование = routeData.Начальная
                });
                stations = LoadStations().ToList();
                startIndex = stations.Find(x => x.Наименование == routeData.Начальная);
            }

            if (finishIndex == null)
            {
                AddStation(new StationData()
                {
                    Наименование = routeData.Конечная
                });
                stations = LoadStations().ToList();
                finishIndex = stations.Find(x => x.Наименование == routeData.Конечная);
            }

            FbClient.ExecuteQuery(string.Format("INSERT INTO ROUTE (START_STATION, FINISH_STATION, PRICE) VALUES ({0}, {1}, '{2}');", startIndex.GetKey(), finishIndex.GetKey(), routeData.Цена));
        }

        internal static object LoadCargos()
        {
            ObservableCollection<CargoData> users = new ObservableCollection<CargoData>();
            List<RouteData> routes = LoadRoutes().ToList();
            List<ClientData> clients = LoadClients().ToList();
            List<ContentsData> content = LoadContents().ToList();

            List<object[]> res = FbClient.ExecuteQuery("select * from CARGO");
            foreach (object[] fields in res)
            {
                CargoData cl = new CargoData()
                {
                    Клиент = clients.Find(x => x.GetKey() == fields[1].ToString().Trim()).Имя + " " + clients.Find(x => x.GetKey() == fields[1].ToString().Trim()).Фамилия,
                    Товар = content.Find(x => x.GetKey() == fields[2].ToString().Trim()).Наименование,
                    Маршрут = routes.Find(x => x.GetKey() == fields[3].ToString().Trim()).Начальная + "-" + routes.Find(x => x.GetKey() == fields[3].ToString().Trim()).Конечная,
                    Дата = fields[4].ToString()
                };
                cl.SetKey(fields[0].ToString().Trim());
                users.Add(cl);
            }
            return users;
        }

        internal static void DeleteRoute(RouteData routeData)
        {
            FbClient.ExecuteQuery(string.Format("DELETE FROM ROUTE WHERE KEY = {0};", routeData.GetKey()));
        }

        internal static void EditContent(ContentsData contentsData)
        {
            FbClient.ExecuteQuery(string.Format("UPDATE CONTENT SET NAME = '{0}' WHERE KEY = {1};", contentsData.Наименование, contentsData.GetKey()));
        }

        internal static void AddContent(ContentsData contentsData)
        {
            FbClient.ExecuteQuery(string.Format("INSERT INTO CONTENT (NAME) VALUES ('{0}');", contentsData.Наименование));
        }

        internal static void DeleteContent(ContentsData contentsData)
        {
            FbClient.ExecuteQuery(string.Format("DELETE FROM CONTENT WHERE KEY = {0};", contentsData.GetKey()));
        }

        internal static void DeleteUser(UserData userData)
        {
            FbClient.ExecuteQuery(string.Format("DELETE FROM USERS WHERE KEY = {0};", userData.GetKey()));
        }

        internal static ObservableCollection<ContentsData> LoadContents()
        {
            ObservableCollection<ContentsData> users = new ObservableCollection<ContentsData>();
            List<object[]> res = FbClient.ExecuteQuery("select * from CONTENT");
            foreach (object[] fields in res)
            {
                ContentsData cl = new ContentsData()
                {
                    Наименование = fields[1].ToString().Trim()
                };
                cl.SetKey(fields[0].ToString().Trim());
                users.Add(cl);
            }
            return users;
        }

        internal static ObservableCollection<StationData> LoadStations()
        {
            ObservableCollection<StationData> users = new ObservableCollection<StationData>();
            List<object[]> res = FbClient.ExecuteQuery("select * from STATION");
            foreach (object[] fields in res)
            {
                StationData cl = new StationData()
                {
                    Наименование = fields[1].ToString().Trim()
                };
                cl.SetKey(fields[0].ToString().Trim());
                users.Add(cl);
            }
            return users;
        }

        internal static ObservableCollection<RouteData> LoadRoutes()
        {
            ObservableCollection<RouteData> users = new ObservableCollection<RouteData>();
            List<StationData> stations = LoadStations().ToList();
            List<object[]> res = FbClient.ExecuteQuery("select * from ROUTE");
            foreach (object[] fields in res)
            {
                RouteData cl = new RouteData()
                {
                    Начальная = stations.Find(x => x.GetKey() == fields[1].ToString().Trim()).Наименование,
                    Конечная = stations.Find(x => x.GetKey() == fields[2].ToString().Trim()).Наименование,
                    Цена = fields[3].ToString().Trim()
                };
                cl.SetKey(fields[0].ToString().Trim());
                users.Add(cl);
            }
            return users;
        }

        //private List<Content> _contents;
        //private List<Route> _routes;
        //private List<Station> _stations;
        //private List<Cargo> _сargos;
        //private List<User> _users;

        //public ObservableCollection<UsersViewModel> Users
        //{
        //    get
        //    {
        //        ObservableCollection<UsersViewModel> res = new ObservableCollection<UsersViewModel>();
        //        foreach (User user in _users)
        //        {
        //            UsersViewModel us = new UsersViewModel() {
        //                Login = user.Name,
        //                Password = user.Passw
        //            };
        //            us.SetKey(user.Key);

        //            res.Add(us);
        //        }
        //        return res;

        //    }
        //}

        //public ObservableCollection<ContentsViewModel> Contents
        //{
        //    get
        //    {
        //        ObservableCollection<ContentsViewModel> res = new ObservableCollection<ContentsViewModel>();
        //        foreach (Content content in _contents)
        //        {
        //            ContentsViewModel vw = new ContentsViewModel()
        //            {
        //                Name = content.Name
        //            };

        //            vw.SetKey(content.Key);
        //            res.Add(vw);

        //        }
        //        return res;
        //    }
        //}

        //public ObservableCollection<RoutesViewModel> Routes
        //{
        //    get
        //    {
        //        ObservableCollection<RoutesViewModel> res = new ObservableCollection<RoutesViewModel>();
        //        foreach (Route route in _routes)
        //        {
        //            RoutesViewModel ro = new RoutesViewModel()
        //            {
        //                Start = _stations.Find(x => x.Key == route.Start).Name,
        //                Finish = _stations.Find(x => x.Key == route.Finish).Name,
        //                Price = route.Price
        //            };

        //            ro.SetKey(route.Key);

        //            res.Add(ro);

        //        }
        //        return res;
        //    }
        //}

        //public ObservableCollection<CargosViewModel> Cargos
        //{
        //    get
        //    {
        //        ObservableCollection<CargosViewModel> res = new ObservableCollection<CargosViewModel>();
        //        foreach (Cargo cargo in _сargos)
        //        {
        //            CargosViewModel car = new CargosViewModel()
        //            {
        //                Date = cargo.Date,
        //                Client = _clients.Find(x => x.GetKey() == cargo.Client).Name + " " + _clients.Find(x => x.GetKey() == cargo.Client).Surname,
        //                Content = _contents.Find(x => x.Key == cargo.Content).Name,
        //                Route = _stations.Find(x => x.Key == _routes.Find(y => y.Key == cargo.Route).Start).Name + "-" +
        //                    _stations.Find(x => x.Key == _routes.Find(y => y.Key == cargo.Route).Finish).Name
        //            };

        //            car.SetKey(cargo.Key);

        //            res.Add(car);

        //        }
        //        return res;
        //    }
        //}



        public UserClient()
        {
            ConnectionStatus = new ConnectionStatus(ConnectionState.Disconnected);
            //_users = new List<User>();
            //_contents = new List<Content>();
            //_stations = new List<Station>();
            //_routes = new List<Route>();
            //_сargos = new List<Cargo>();
        }

        public async void Connect(Credentials user)
        {
            ConnectionStatus.Set(ConnectionState.Connecting);

            var userValid = await Task<List<object[]>>.Factory.StartNew(() =>
            {
                return FbClient.ExecuteReaderCommand(new FbCommandArgs(
                    "IS_USER",
                    new List<FbCommandParameterArgs>()
                    {
                        new FbCommandParameterArgs("@NAME", FbDbType.VarChar, user.Account),
                        new FbCommandParameterArgs("@PASS", FbDbType.VarChar, user.Password)

                    }));

            });

            if (userValid.Count != 0)
            {
                if (userValid[0][0].ToString() == "1")
                {
                    CurrentUser = LoadUser(user);
                    ConnectionStatus.Set(ConnectionState.Connected);
                }

                if (userValid[0][0].ToString() == "0")
                {
                    ConnectionStatus.Set(ConnectionState.Disconnected, "Wrong login or password");
                }
            }
            else
            {
                ConnectionStatus.Set(ConnectionState.Disconnected, "Error of database");
            }          
        }

        static public ObservableCollection<ClientData> LoadClients()
        {
            ObservableCollection<ClientData> _clients = new ObservableCollection<ClientData>();
            List<object[]> res = FbClient.ExecuteQuery("select * from CLIENT");
            foreach (object[] fields in res)
            {
                ClientData cl = new ClientData()
                {
                    Имя = fields[1].ToString().Trim(),
                    Фамилия = fields[2].ToString().Trim(),
                    Компания = fields[3].ToString().Trim(),
                };
                cl.SetKey(fields[0].ToString().Trim());
                _clients.Add(cl);
            }
            return _clients;
        }

        static public void EditClient(ClientData client)
        {
            FbClient.ExecuteQuery(string.Format("UPDATE CLIENT SET NAME = '{0}', SURNAME = '{1}', COMPANY = '{2}' WHERE KEY = {3};", client.Имя, client.Фамилия, client.Компания, client.GetKey()));
        }

        static public void DeleteClient(ClientData client)
        {
            FbClient.ExecuteQuery(string.Format("DELETE FROM CLIENT WHERE KEY = {0};", client.GetKey()));
        }

        static public void AddClient(ClientData client)
        {
            FbClient.ExecuteQuery(string.Format("INSERT INTO CLIENT (NAME, SURNAME, COMPANY) VALUES ('{0}','{1}','{2}');", client.Имя, client.Фамилия, client.Компания));
        }

        static public ObservableCollection<UserData> LoadUsers()
        {
            ObservableCollection<UserData> users = new ObservableCollection<UserData>();
            List<object[]> res = FbClient.ExecuteQuery("select * from USERS");
            foreach (object[] fields in res)
            {
                UserData cl = new UserData()
                {
                    Логин = fields[1].ToString().Trim(),
                    Пароль = fields[2].ToString().Trim(),            
                    Грузы = Convert.ToBoolean(Convert.ToInt32(fields[3].ToString().Trim())),
                    Клиенты = Convert.ToBoolean(Convert.ToInt32(fields[4].ToString().Trim())),
                    Товары = Convert.ToBoolean(Convert.ToInt32(fields[5].ToString().Trim())),
                    Маршруты = Convert.ToBoolean(Convert.ToInt32(fields[6].ToString().Trim())),
                    Пользователи = Convert.ToBoolean(Convert.ToInt32(fields[7].ToString().Trim())),
                    Станции = Convert.ToBoolean(Convert.ToInt32(fields[8].ToString().Trim()))
                };
                cl.SetKey(fields[0].ToString().Trim());
                users.Add(cl);
            }
            return users;
        }

        static public UserData LoadUser(Credentials credit)
        {
            UserData user = new UserData();
            List<object[]> res = FbClient.ExecuteQuery(String.Format("select * from USERS WHERE NAME = '{0}' AND PASS = '{1}'", credit.Account, credit.Password));
            foreach (object[] fields in res)
            {
                user = new UserData()
                {
                    Логин = fields[1].ToString().Trim(),
                    Грузы = Convert.ToBoolean(Convert.ToInt32(fields[3].ToString().Trim())),
                    Клиенты = Convert.ToBoolean(Convert.ToInt32(fields[4].ToString().Trim())),
                    Товары = Convert.ToBoolean(Convert.ToInt32(fields[5].ToString().Trim())),
                    Маршруты = Convert.ToBoolean(Convert.ToInt32(fields[6].ToString().Trim())),
                    Пользователи = Convert.ToBoolean(Convert.ToInt32(fields[7].ToString().Trim())),
                    Станции = Convert.ToBoolean(Convert.ToInt32(fields[8].ToString().Trim()))
                };
                user.SetKey(fields[0].ToString().Trim());
            }
            return user;
        }

        //public void LoadUsers()
        //{
        //    List<object[]> res = FbClient.ExecuteQuery("select * from USERS");
        //    foreach (object[] fields in res)
        //    {
        //        _users.Add(new User()
        //        {
        //            Key = fields[0].ToString().Trim(),
        //            Name = fields[1].ToString().Trim(),
        //            Passw = fields[2].ToString().Trim()
        //        });
        //    }
        //}

        //public void LoadContents()
        //{
        //    List<object[]> res = FbClient.ExecuteQuery("select * from CONTENT");
        //    foreach (object[] fields in res)
        //    {
        //        _contents.Add(new Content()
        //        {
        //            Key = fields[0].ToString().Trim(),
        //            Name = fields[1].ToString().Trim(),
        //        });
        //    }
        //}

        //public void LoadStations()
        //{
        //    List<object[]> res = FbClient.ExecuteQuery("select * from STATION");
        //    foreach (object[] fields in res)
        //    {
        //        _stations.Add(new Station()
        //        {
        //            Key = fields[0].ToString().Trim(),
        //            Name = fields[1].ToString().Trim(),
        //        });
        //    }
        //}

        //public void LoadRoutes()
        //{
        //    List<object[]> res = FbClient.ExecuteQuery("select * from ROUTE");
        //    foreach (object[] fields in res)
        //    {
        //        _routes.Add(new Route()
        //        {
        //            Key = fields[0].ToString().Trim(),
        //            Start = fields[1].ToString().Trim(),
        //            Finish = fields[2].ToString().Trim(),
        //            Price = fields[3].ToString().Trim()
        //        });
        //    }
        //}

        //public void LoadCargos()
        //{
        //    List<object[]> res = FbClient.ExecuteQuery("select * from CARGO");
        //    foreach (object[] fields in res)
        //    {
        //        _сargos.Add(new Cargo()
        //        {
        //            Key = fields[0].ToString().Trim(),
        //            Client = fields[1].ToString().Trim(),
        //            Content = fields[2].ToString().Trim(),
        //            Route = fields[3].ToString().Trim(),
        //            Date = fields[4].ToString().Trim(),
        //        });
        //    }
        //}

        //public void LoadAll()
        //{
        //    LoadCargos();
        //    LoadClients();
        //    LoadContents();
        //    LoadRoutes();
        //    LoadStations();
        //    LoadUsers();
        //}
    }
}
