//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: ServiceDat.proto
namespace ServiceDat
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"UploadItemInfo")]
  public partial class UploadItemInfo : global::ProtoBuf.IExtensible
  {
    public UploadItemInfo() {}
    
    private string _imei;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"imei", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string imei
    {
      get { return _imei; }
      set { _imei = value; }
    }
    private string _name;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string name
    {
      get { return _name; }
      set { _name = value; }
    }
    private string _item;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string item
    {
      get { return _item; }
      set { _item = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}