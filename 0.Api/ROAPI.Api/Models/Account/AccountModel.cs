using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROAPI.Api.Models.Account
{
    public class AccountModel: IDisposable
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Sex { get; set; }
        public string Email { get; set; }
        public int GroupId { get; set; }
        public int State { get; set; }
        public int UnbanTime { get; set; }
        public int ExpirationTime { get; set; }
        public int LoginCount { get; set; }
        public DateTime? LastLogin { get; set; }
        public string LastIp { get; set; }
        public DateTime? BirthDate { get; set; }
        public int CharacterSlots { get; set; }
        public string Pincode { get; set; }
        public int PincodeChange { get; set; }
        public int VipTime { get; set; }
        public int OldGroup { get; set; }
        public string GetGroupRole()
        {
            string _group_role = "";
            switch (GroupId)
            {
                case 99:
                    _group_role = "Admin";
                    break;
                case 10:
                    _group_role = "Law Enforcement";
                    break;
                case 5:
                    _group_role = "VIP";
                    break;
                case 4:
                    _group_role = "Event Manager";
                    break;
                case 3:
                    _group_role = "Script Manager";
                    break;
                case 2:
                    _group_role = "Support";
                    break;
                case 1:
                    _group_role = "Super Player";
                    break;
                case 0:
                    _group_role = "Player";
                    break;

            }
            return _group_role;
        }

        #region [IDisposable Support]
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~Account() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
