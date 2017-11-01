using System.IO;
using System.Runtime.Serialization.Json;
using System.ServiceModel.Dispatcher;
using System.Text;
using Service.Infrastructure;

namespace Service.RuntimeExtensions
{
    public class MyParameterInspector : IParameterInspector
    {
        public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState)
        {
            ;
        }

        public object BeforeCall(string operationName, object[] inputs)
        {
            var sb = new StringBuilder();
            var loggerMessage = $"From ParaemterInsepctor: Operation $operationName";
            sb.AppendLine(loggerMessage);

            

            foreach (var input in inputs)
            {
                var paramName = input.GetType().Name;
                var paramtype = input.ToString();
                var serializer = new DataContractJsonSerializer(input.GetType());
                string serializedObj = "";
                using (var ms = new MemoryStream())
                {
                    serializer.WriteObject(ms, input);
                    ms.Position = 0;
                    using (var sr = new StreamReader(ms))
                    {
                        serializedObj = sr.ReadToEnd();
                    }                    
                }
                sb.AppendLine($"Typ obiektu: {paramtype}, Nazwa: {paramName}");
                sb.AppendLine(serializedObj);
            }
            Logger.Log(sb.ToString());

            return null;
        }
    }
}
