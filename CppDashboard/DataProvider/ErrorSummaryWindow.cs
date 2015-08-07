using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using CppDashboard.DataProvider.Setup;
using CppDashboard.Models;

namespace CppDashboard.DataProvider
{
    public class ErrorSummaryWindow : DataLoadBase<ErrorSummary>
    {
        public IEnumerable<ErrorSummary> ErrorSummaries
        {
            get
            {
                return _summary;
            }
        }

        private readonly string _sql;
        private readonly ConnectionCreator _connectionCreator;
        private IEnumerable<ErrorSummary> _summary; 

        public ErrorSummaryWindow()
        {
            _sql = GetSqlScript();
            _connectionCreator = new ConnectionCreator(Scope.Monitoring);
        }

        public override IEnumerable<ErrorSummary> Load(int duration)
        {
            _summary = _connectionCreator.Exec<ErrorSummary>(_sql);
            return _summary;
        }

        protected override bool AllowedPeriod(ErrorSummary input)
        {
            return true;
        }

        protected override IEnumerable<ErrorSummary> LoadingFrom(int primaryKey)
        {
            return _connectionCreator.Exec<ErrorSummary>(_sql);
        }

        private string GetSqlScript()
        {
            var sqlFilePath = string.Concat(AssemblyDirectory, "\\DataProvider\\sql\\SystemErrorSummary.sql");
            var readStream = new StreamReader(sqlFilePath);
            var sql = readStream.ReadToEnd();
            readStream.Close();

            sql = sql.Replace("[LogDurationWindow]", Constants.SummaryDurationInHours.ToString());

            return sql;
        }

        private static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }
    }
}