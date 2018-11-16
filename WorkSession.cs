﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Gamma
{
    public static class WorkSession
    {
        public static Guid ParamID { get; set; }
        private static Guid _userid;
        public static Guid UserID
        {
            get
            {
                return _userid;
            }
            set
            {
            	_userid = value;
                var userInfo = (from u in DB.GammaDb.Users
                                 where
                                     u.UserID == _userid
                                 select new
                                 {
                                     u.Places.FirstOrDefault().PlaceID,
                                     placeGroupID = u.Places.FirstOrDefault().PlaceGroupID, u.ShiftID, u.DBAdmin,
                                     programAdmin = u.ProgramAdmin,
                                     u.Places.FirstOrDefault().BranchID,
                                     u.Places.FirstOrDefault().IsProductionPlace,
                                     u.Places,
                                     u.DepartmentID,
                                     u.Name,
                                     u.Places.FirstOrDefault().IsShipmentWarehouse,
                                     u.Places.FirstOrDefault().IsTransitWarehouse
                                 }).FirstOrDefault();
                if (userInfo == null)
                {
                    MessageBox.Show("Не удалось получить информацию о пользователе");
                    return;
                }
                UserName = userInfo.Name;
                DBAdmin = userInfo.DBAdmin;
                ProgramAdmin = userInfo.programAdmin ?? false;
                PlaceID = userInfo.PlaceID;
                DepartmentID = userInfo.DepartmentID; /*(from u in DB.GammaDb.Places
                                    where u.PlaceID == PlaceID
                                    select u.DepartmentID
                                ).FirstOrDefault();*/
                BranchID = userInfo.BranchID;
                ShiftID = userInfo.ShiftID;
                PlaceGroup = (PlaceGroup)userInfo.placeGroupID;
                IsProductionPlace = userInfo.IsProductionPlace ?? false;
                IsShipmentWarehouse = userInfo.IsShipmentWarehouse ?? false;
                IsTransitWarehouse = userInfo.IsTransitWarehouse ?? false;
                PlaceIds = userInfo.Places.Select(p => p.PlaceID).ToList();
                BranchIds = userInfo.Places.Select(p => p.BranchID).Distinct().ToList();
                IsRemotePrinting = userInfo.Places.FirstOrDefault()?.IsRemotePrinting ?? false;
                UseApplicator = userInfo.Places.FirstOrDefault()?.UseApplicator ?? false;
                EndpointAddressOnMailService = (from u in DB.GammaDb.LocalSettings
                                   select u.MailServiceAddress).FirstOrDefault();
                EndpointAddress = (from u in DB.GammaDb.PlaceRemotePrinters
                                   where u.PlaceID == PlaceID && u.RemotePrinters.RemotePrinterLabelID == 2
                                   select u.ModbusDevices.ServiceAddress).FirstOrDefault();
#if (DEBUG)
                EndpointAddressOnMailService = "http://localhost:8733/PrinterService";
                EndpointAddress = "http://localhost:8733/PrinterService";
#endif
                LabelPath = (from u in DB.GammaDb.LocalSettings
                                   select u.LabelPath).FirstOrDefault();
            }
        }
        public static bool DBAdmin
        {
            get; private set;
        }

        public static int PlaceID
        {
            get; private set;
        }

        public static int? DepartmentID
        {
            get; private set;
        }

        public static int BranchID { get; private set; }
        public static bool ProgramAdmin
        {
            get; private set;
        }
        public static byte ShiftID
        {
            get; private set;
        }
        /// <summary>
        /// Признак печати транспортной этикетки на удаленном принтере
        /// </summary>
        public static bool IsRemotePrinting { get; private set; }
        /// <summary>
        /// Признак автоматической печати и наклейки групповой этикетки 
        /// </summary>
        public static bool UseApplicator { get; private set; }

        public static List<int> PlaceIds { get; private set; }
        public static List<int> BranchIds { get; private set; }

        public static bool IsProductionPlace { get; private set; }
        public static bool IsShipmentWarehouse { get; private set; }
        public static bool IsTransitWarehouse { get; private set; }
        public static PlaceGroup PlaceGroup { get; private set; }
        public static string PrintName { get; set; }
        public static string UserName { get; private set; }
        public static Guid? PersonID { get; set; }

        public static string EndpointConfigurationName = "BasicHttpBinding_IPrinterService";

        /// <summary>
        /// Адрес сервиса отправки электронных писем MailService
        /// </summary>

        public static string EndpointAddressOnMailService { get; private set; }
        /// <summary>
        /// Адрес сервиса печати этикеток GammaService
        /// </summary>
        public static string EndpointAddress { get; private set; }

        /// <summary>
        /// Путь до этикеток (групповых, транспортных)
        /// </summary>
        public static string LabelPath { get; private set; }
    }
}
