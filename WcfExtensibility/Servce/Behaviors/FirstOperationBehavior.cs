using System;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using Service.RuntimeExtensions;

namespace Service.Behaviors
{
    public class FirstOperationBehaviorAttribute : Attribute, IOperationBehavior
    {
        public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
        {
            ;
        }

        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
        {
            ;
        }

        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            dispatchOperation.Parent.MessageInspectors.Add(new MyMessageInspector());
            dispatchOperation.ParameterInspectors.Add(new MyParameterInspector());
        }

        public void Validate(OperationDescription operationDescription)
        {
            ;
        }
    }
}
