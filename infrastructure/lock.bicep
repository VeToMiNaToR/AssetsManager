targetScope = 'resourceGroup'

resource dontDeleteLock 'Microsoft.Authorization/locks@2017-04-01' = {
  name: 'nodelete'
  properties: {
    level: 'CanNotDelete'
    notes: 'Prevent deletion of the resources at the provided level.'
  }
}
