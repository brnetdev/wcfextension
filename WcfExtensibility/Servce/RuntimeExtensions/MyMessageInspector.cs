using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Xml;
using Service.Infrastructure;

namespace Service.RuntimeExtensions
{
    public class MyMessageInspector : IDispatchMessageInspector
    {
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            var bufferedMessage = request.CreateBufferedCopy(int.MaxValue);
            var message = bufferedMessage.CreateMessage();
            var reader = message.GetReaderAtBodyContents();
            
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(reader);
            var logMessage = $"From mnessage inspector\n{xmlDoc.OuterXml}";
            Logger.Log(logMessage);

            request = bufferedMessage.CreateMessage();
            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            ;
        }
    }
}
