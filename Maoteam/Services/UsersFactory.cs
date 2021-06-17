using LdapForNet;
using MaoTeam.Models;
using MaoTeam.Utils;
using System;
using System.Globalization;
using System.Linq;

namespace MaoTeam.Services
{
    public static class UsersFactory
    {
        public static AdUser CreateAdUser(LdapEntry ldapEntry)
        {
            if (ldapEntry == null)
                throw new ArgumentNullException(nameof(ldapEntry), $"{nameof(ldapEntry)} is null.");
            string format = "yyyyMMddHHmmss.f'Z'";

            return new AdUser
            {
                SamAccountName = FetchResult(ldapEntry, LdapAttributes.SAmAccountName, (entry) => entry.GetValue<string>(), string.Empty),
                ObjectSid = FetchResult(ldapEntry, LdapAttributes.ObjectSid, (entry) => LdapSidConverter.ParseFromBytes(entry.GetValue<byte[]>()), string.Empty),
                Cn = FetchResult(ldapEntry, LdapAttributes.Cn, (entry) => entry.GetValue<string>(), string.Empty),
                DistinguishedName = ldapEntry.Dn,
                Sn = FetchResult(ldapEntry, LdapAttributes.Sn, (entry) => entry.GetValue<string>(), string.Empty),
                GivenName = FetchResult(ldapEntry, LdapAttributes.GivenName, (entry) => entry.GetValue<string>(), string.Empty),
                DisplayName = FetchResult(ldapEntry, LdapAttributes.DisplayName, (entry) => entry.GetValue<string>(), string.Empty),
                Name = FetchResult(ldapEntry, LdapAttributes.Name, (entry) => entry.GetValue<string>(), string.Empty),
                UserPrincipalName = FetchResult(ldapEntry, LdapAttributes.UserPrincipalName, (entry) => entry.GetValue<string>(), string.Empty),
                TelephoneNumber = FetchResult(ldapEntry, LdapAttributes.TelephoneNumber, (entry) => entry.GetValue<string>(), string.Empty),
                Mail = FetchResult(ldapEntry, LdapAttributes.Mail, (entry) => entry.GetValue<string>(), string.Empty),
                WhenCreated = FetchResult(ldapEntry, LdapAttributesExtended.WhenCreated, (entry) => DateTimeOffset.ParseExact(entry.GetValue<string>(), format, CultureInfo.InvariantCulture), default(DateTimeOffset)),
                LastLogon = FetchResult(ldapEntry, LdapAttributesExtended.LastLogonTimestamp, (entry) => DateTimeOffset.FromFileTime(long.Parse(entry.GetValue<string>())), default(DateTimeOffset)),
                WhenChanged = FetchResult(ldapEntry, LdapAttributes.WhenChanged, (entry) => DateTimeOffset.ParseExact(entry.GetValue<string>(), format, CultureInfo.InvariantCulture), default(DateTimeOffset)),
                AccountExpires = FetchResult(ldapEntry, LdapAttributesExtended.AccountExpires, (entry) => long.Parse(entry.GetValue<string>()), default(long)),
                ObjectGUID = FetchResult(ldapEntry, LdapAttributes.ObjectGuid, (entry) => new Guid(entry.GetValue<byte[]>()), Guid.Empty),
                BadPwdCount = FetchResult(ldapEntry, LdapAttributesExtended.BadPwdCount, (entry) => int.Parse(entry.GetValue<string>()), default(int)),
                MemberOf = FetchResult(ldapEntry, LdapAttributes.MemberOf, (entry) => entry.GetValues<string>(), Enumerable.Empty<string>())
            };
        }

        static TResult FetchResult<TResult>(LdapEntry ldapEntry, string ldapAttribute, Func<DirectoryAttribute, TResult> valueFunc, TResult defaultValue) =>
            ldapEntry.DirectoryAttributes.Contains(ldapAttribute) ? valueFunc(ldapEntry.DirectoryAttributes[ldapAttribute]) : defaultValue;
    }
}
