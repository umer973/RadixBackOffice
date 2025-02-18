﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.Models;
using DbHelper.DbContext;

namespace BusinessLogic.Partner
{
    public class Partner : IPartner
    {
        public List<PartnerModel> GetPartners()
        {
            try
            {
                using (var query = new SqlQuery())
                {
                    var result = query.ExecuteNonQuery<PartnerModel>("sp_GetPartners", new Dictionary<string, object>
                    {
                        {"PId",2 }

                    }).ToList();

                    return result;
                }
            }
            catch (Exception ex)
            {
                //Logger.LogError("Client:GetClients", ex.Message);
                throw;
            }
        }

        public int InsertPartners(PartnerModel Partner)
        {
            try
            {
                using (var query = new SqlQuery())
                {
                    var result = query.ExecuteNonQuery("InsertUpdatePartners", new Dictionary<string, object>
                    {
                        {"PartnerId" ,Partner.PartnerId},
                        {"PartnerName",Partner.PartnerName},
                        {"ContactNo",Partner.ContactNo },
                        {"Email",Partner.Email},
                        {"Address",Partner.Address},
                       
                       
                        {"IsActive",Partner.IsActive }

                    });
                    return result;
                }
            }
            catch (Exception ex)
            {
                //Logger.LogError("Admin:Login", ex.Message);
                string msg = ex.ToString();
                throw;
            }
        }
    }
}
