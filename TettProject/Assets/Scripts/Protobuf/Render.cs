// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: render.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace OfflineRender {

  /// <summary>Holder for reflection information generated from render.proto</summary>
  public static partial class RenderReflection {

    #region Descriptor
    /// <summary>File descriptor for render.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static RenderReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CgxyZW5kZXIucHJvdG8SDW9mZmxpbmVSZW5kZXIiRAoOU3RhcnRSZW5kZXJS",
            "ZXESDgoGbWFwX2lkGAEgASgJEhAKCGpzb25fdXJsGAIgASgJEhAKCGNtZF90",
            "eXBlGAMgASgFIiUKDlN0YXJ0UmVuZGVyUnNwEhMKC3Jlc3VsdF9jb2RlGAEg",
            "ASgFIl4KD0ZpbmlzaFJlbmRlclJlcRIOCgZtYXBfaWQYASABKAkSFAoMcGF0",
            "aF9hbmRyb2lkGAIgASgJEhAKCHBhdGhfaW9zGAMgASgJEhMKC3Jlc3VsdF9j",
            "b2RlGAQgASgFIiYKD0ZpbmlzaFJlbmRlclJzcBITCgtyZXN1bHRfY29kZRgB",
            "IAEoBTKwAQoNUmVuZGVyU2VydmljZRJNCgtTdGFydFJlbmRlchIdLm9mZmxp",
            "bmVSZW5kZXIuU3RhcnRSZW5kZXJSZXEaHS5vZmZsaW5lUmVuZGVyLlN0YXJ0",
            "UmVuZGVyUnNwIgASUAoMRmluaXNoUmVuZGVyEh4ub2ZmbGluZVJlbmRlci5G",
            "aW5pc2hSZW5kZXJSZXEaHi5vZmZsaW5lUmVuZGVyLkZpbmlzaFJlbmRlclJz",
            "cCIAYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::OfflineRender.StartRenderReq), global::OfflineRender.StartRenderReq.Parser, new[]{ "MapId", "JsonUrl", "CmdType" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::OfflineRender.StartRenderRsp), global::OfflineRender.StartRenderRsp.Parser, new[]{ "ResultCode" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::OfflineRender.FinishRenderReq), global::OfflineRender.FinishRenderReq.Parser, new[]{ "MapId", "PathAndroid", "PathIos", "ResultCode" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::OfflineRender.FinishRenderRsp), global::OfflineRender.FinishRenderRsp.Parser, new[]{ "ResultCode" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class StartRenderReq : pb::IMessage<StartRenderReq>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<StartRenderReq> _parser = new pb::MessageParser<StartRenderReq>(() => new StartRenderReq());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<StartRenderReq> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::OfflineRender.RenderReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public StartRenderReq() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public StartRenderReq(StartRenderReq other) : this() {
      mapId_ = other.mapId_;
      jsonUrl_ = other.jsonUrl_;
      cmdType_ = other.cmdType_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public StartRenderReq Clone() {
      return new StartRenderReq(this);
    }

    /// <summary>Field number for the "map_id" field.</summary>
    public const int MapIdFieldNumber = 1;
    private string mapId_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string MapId {
      get { return mapId_; }
      set {
        mapId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "json_url" field.</summary>
    public const int JsonUrlFieldNumber = 2;
    private string jsonUrl_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string JsonUrl {
      get { return jsonUrl_; }
      set {
        jsonUrl_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "cmd_type" field.</summary>
    public const int CmdTypeFieldNumber = 3;
    private int cmdType_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CmdType {
      get { return cmdType_; }
      set {
        cmdType_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as StartRenderReq);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(StartRenderReq other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (MapId != other.MapId) return false;
      if (JsonUrl != other.JsonUrl) return false;
      if (CmdType != other.CmdType) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (MapId.Length != 0) hash ^= MapId.GetHashCode();
      if (JsonUrl.Length != 0) hash ^= JsonUrl.GetHashCode();
      if (CmdType != 0) hash ^= CmdType.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (MapId.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(MapId);
      }
      if (JsonUrl.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(JsonUrl);
      }
      if (CmdType != 0) {
        output.WriteRawTag(24);
        output.WriteInt32(CmdType);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (MapId.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(MapId);
      }
      if (JsonUrl.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(JsonUrl);
      }
      if (CmdType != 0) {
        output.WriteRawTag(24);
        output.WriteInt32(CmdType);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (MapId.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(MapId);
      }
      if (JsonUrl.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(JsonUrl);
      }
      if (CmdType != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(CmdType);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(StartRenderReq other) {
      if (other == null) {
        return;
      }
      if (other.MapId.Length != 0) {
        MapId = other.MapId;
      }
      if (other.JsonUrl.Length != 0) {
        JsonUrl = other.JsonUrl;
      }
      if (other.CmdType != 0) {
        CmdType = other.CmdType;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            MapId = input.ReadString();
            break;
          }
          case 18: {
            JsonUrl = input.ReadString();
            break;
          }
          case 24: {
            CmdType = input.ReadInt32();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            MapId = input.ReadString();
            break;
          }
          case 18: {
            JsonUrl = input.ReadString();
            break;
          }
          case 24: {
            CmdType = input.ReadInt32();
            break;
          }
        }
      }
    }
    #endif

  }

  public sealed partial class StartRenderRsp : pb::IMessage<StartRenderRsp>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<StartRenderRsp> _parser = new pb::MessageParser<StartRenderRsp>(() => new StartRenderRsp());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<StartRenderRsp> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::OfflineRender.RenderReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public StartRenderRsp() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public StartRenderRsp(StartRenderRsp other) : this() {
      resultCode_ = other.resultCode_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public StartRenderRsp Clone() {
      return new StartRenderRsp(this);
    }

    /// <summary>Field number for the "result_code" field.</summary>
    public const int ResultCodeFieldNumber = 1;
    private int resultCode_;
    /// <summary>
    ///返回码
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int ResultCode {
      get { return resultCode_; }
      set {
        resultCode_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as StartRenderRsp);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(StartRenderRsp other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (ResultCode != other.ResultCode) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (ResultCode != 0) hash ^= ResultCode.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (ResultCode != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(ResultCode);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (ResultCode != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(ResultCode);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (ResultCode != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(ResultCode);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(StartRenderRsp other) {
      if (other == null) {
        return;
      }
      if (other.ResultCode != 0) {
        ResultCode = other.ResultCode;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            ResultCode = input.ReadInt32();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 8: {
            ResultCode = input.ReadInt32();
            break;
          }
        }
      }
    }
    #endif

  }

  public sealed partial class FinishRenderReq : pb::IMessage<FinishRenderReq>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<FinishRenderReq> _parser = new pb::MessageParser<FinishRenderReq>(() => new FinishRenderReq());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<FinishRenderReq> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::OfflineRender.RenderReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public FinishRenderReq() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public FinishRenderReq(FinishRenderReq other) : this() {
      mapId_ = other.mapId_;
      pathAndroid_ = other.pathAndroid_;
      pathIos_ = other.pathIos_;
      resultCode_ = other.resultCode_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public FinishRenderReq Clone() {
      return new FinishRenderReq(this);
    }

    /// <summary>Field number for the "map_id" field.</summary>
    public const int MapIdFieldNumber = 1;
    private string mapId_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string MapId {
      get { return mapId_; }
      set {
        mapId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "path_android" field.</summary>
    public const int PathAndroidFieldNumber = 2;
    private string pathAndroid_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string PathAndroid {
      get { return pathAndroid_; }
      set {
        pathAndroid_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "path_ios" field.</summary>
    public const int PathIosFieldNumber = 3;
    private string pathIos_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string PathIos {
      get { return pathIos_; }
      set {
        pathIos_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "result_code" field.</summary>
    public const int ResultCodeFieldNumber = 4;
    private int resultCode_;
    /// <summary>
    ///渲染是否成功返回码
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int ResultCode {
      get { return resultCode_; }
      set {
        resultCode_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as FinishRenderReq);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(FinishRenderReq other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (MapId != other.MapId) return false;
      if (PathAndroid != other.PathAndroid) return false;
      if (PathIos != other.PathIos) return false;
      if (ResultCode != other.ResultCode) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (MapId.Length != 0) hash ^= MapId.GetHashCode();
      if (PathAndroid.Length != 0) hash ^= PathAndroid.GetHashCode();
      if (PathIos.Length != 0) hash ^= PathIos.GetHashCode();
      if (ResultCode != 0) hash ^= ResultCode.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (MapId.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(MapId);
      }
      if (PathAndroid.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(PathAndroid);
      }
      if (PathIos.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(PathIos);
      }
      if (ResultCode != 0) {
        output.WriteRawTag(32);
        output.WriteInt32(ResultCode);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (MapId.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(MapId);
      }
      if (PathAndroid.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(PathAndroid);
      }
      if (PathIos.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(PathIos);
      }
      if (ResultCode != 0) {
        output.WriteRawTag(32);
        output.WriteInt32(ResultCode);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (MapId.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(MapId);
      }
      if (PathAndroid.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(PathAndroid);
      }
      if (PathIos.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(PathIos);
      }
      if (ResultCode != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(ResultCode);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(FinishRenderReq other) {
      if (other == null) {
        return;
      }
      if (other.MapId.Length != 0) {
        MapId = other.MapId;
      }
      if (other.PathAndroid.Length != 0) {
        PathAndroid = other.PathAndroid;
      }
      if (other.PathIos.Length != 0) {
        PathIos = other.PathIos;
      }
      if (other.ResultCode != 0) {
        ResultCode = other.ResultCode;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            MapId = input.ReadString();
            break;
          }
          case 18: {
            PathAndroid = input.ReadString();
            break;
          }
          case 26: {
            PathIos = input.ReadString();
            break;
          }
          case 32: {
            ResultCode = input.ReadInt32();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            MapId = input.ReadString();
            break;
          }
          case 18: {
            PathAndroid = input.ReadString();
            break;
          }
          case 26: {
            PathIos = input.ReadString();
            break;
          }
          case 32: {
            ResultCode = input.ReadInt32();
            break;
          }
        }
      }
    }
    #endif

  }

  public sealed partial class FinishRenderRsp : pb::IMessage<FinishRenderRsp>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<FinishRenderRsp> _parser = new pb::MessageParser<FinishRenderRsp>(() => new FinishRenderRsp());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<FinishRenderRsp> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::OfflineRender.RenderReflection.Descriptor.MessageTypes[3]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public FinishRenderRsp() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public FinishRenderRsp(FinishRenderRsp other) : this() {
      resultCode_ = other.resultCode_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public FinishRenderRsp Clone() {
      return new FinishRenderRsp(this);
    }

    /// <summary>Field number for the "result_code" field.</summary>
    public const int ResultCodeFieldNumber = 1;
    private int resultCode_;
    /// <summary>
    ///返回码
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int ResultCode {
      get { return resultCode_; }
      set {
        resultCode_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as FinishRenderRsp);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(FinishRenderRsp other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (ResultCode != other.ResultCode) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (ResultCode != 0) hash ^= ResultCode.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (ResultCode != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(ResultCode);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (ResultCode != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(ResultCode);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (ResultCode != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(ResultCode);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(FinishRenderRsp other) {
      if (other == null) {
        return;
      }
      if (other.ResultCode != 0) {
        ResultCode = other.ResultCode;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            ResultCode = input.ReadInt32();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 8: {
            ResultCode = input.ReadInt32();
            break;
          }
        }
      }
    }
    #endif

  }

  #endregion

}

#endregion Designer generated code
