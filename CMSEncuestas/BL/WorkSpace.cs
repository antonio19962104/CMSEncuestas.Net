﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class WorkSpace
    {
        public static MappingConfigurations Convert = new MappingConfigurations();
        public static List<ML.WorkSpace> GetWorkSpaceByIdAdmin(ML.Administrador aAdministrador)
        {
            try
            {
                var list = new List<ML.WorkSpace>();
                using (DL.CmsEncuestasEntities context = new DL.CmsEncuestasEntities())
                {
                    var IdWorkSpace = context.Administrador_WorkSpace.Where(o => o.IdAdministrador == aAdministrador.IdAdministrador).FirstOrDefault();
                    if (IdWorkSpace == null)
                        return new List<ML.WorkSpace>();
                    var WorkSpace = context.WorkSpace.Where(o => o.IdWorkSpace == IdWorkSpace.IdWorkSpace && o.IdEstatus == 1).ToList();
                    foreach (var elem in WorkSpace)
                        list.Add(Convert.ToModelWorkSpace(elem));
                    return list;
                }
            }
            catch (Exception aE)
            {
                BL.Nlog.logErrorModuloWorkSpace(aE, new StackTrace(true));
                return new List<ML.WorkSpace>();
            }
        }
    }
}
