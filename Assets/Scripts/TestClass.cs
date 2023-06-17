using Normal.Realtime;

using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts
{
    public class TestClass : RealtimeComponent<TestModel>
    {

        RealtimeTransform _realtimeTransform;
        public void Start()
        {
            _realtimeTransform = GetComponent<RealtimeTransform>();
            _realtimeTransform.ownerIDSelfDidChange += OwnerIDSelfDidChange;
            Debug.Log("Press space to request ownership");
        }      
        private void Update()
        {   
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Rquesting ownership");
                GetComponent<RealtimeTransform>().RequestOwnership();
            }
        }

        protected override void OnRealtimeModelReplaced(TestModel previousModel,
            TestModel currentModel)
        {
            
        }

        private void OwnerIDSelfDidChange(RealtimeComponent<RealtimeTransformModel> arg1, int arg2)
        {
            Debug.Log($"OwnerIdDidChange {arg1.name} {arg2}");
        }

        
    }
}
