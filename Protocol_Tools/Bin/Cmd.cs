//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: Cmd.proto
namespace Cmd
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Default_out")]
  public partial class Default_out : global::ProtoBuf.IExtensible
  {
    public Default_out() {}
    
    private Status _status;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"status", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public Status status
    {
      get { return _status; }
      set { _status = value; }
    }
    private string _info;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"info", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string info
    {
      get { return _info; }
      set { _info = value; }
    }

    private string _message = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"message", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string message
    {
      get { return _message; }
      set { _message = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
    [global::ProtoBuf.ProtoContract(Name=@"Status")]
    public enum Status
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"FAILURE", Value=0)]
      FAILURE = 0,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SUCCESS", Value=1)]
      SUCCESS = 1,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MESSAGE", Value=2)]
      MESSAGE = 2
    }
  
}