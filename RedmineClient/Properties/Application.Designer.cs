﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RedmineClient.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
    internal sealed partial class Application : global::System.Configuration.ApplicationSettingsBase {
        
        private static Application defaultInstance = ((Application)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Application())));
        
        public static Application Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool ask_before_exit {
            get {
                return ((bool)(this["ask_before_exit"]));
            }
            set {
                this["ask_before_exit"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool minimaze_to_tray {
            get {
                return ((bool)(this["minimaze_to_tray"]));
            }
            set {
                this["minimaze_to_tray"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool show_status_bar {
            get {
                return ((bool)(this["show_status_bar"]));
            }
            set {
                this["show_status_bar"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool show_account_login {
            get {
                return ((bool)(this["show_account_login"]));
            }
            set {
                this["show_account_login"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool enable_encryption {
            get {
                return ((bool)(this["enable_encryption"]));
            }
            set {
                this["enable_encryption"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool background_updater_enable {
            get {
                return ((bool)(this["background_updater_enable"]));
            }
            set {
                this["background_updater_enable"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("60000")]
        public long background_updater_interval {
            get {
                return ((long)(this["background_updater_interval"]));
            }
            set {
                this["background_updater_interval"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://student-rm.exactpro.com/")]
        public string redmine_host {
            get {
                return ((string)(this["redmine_host"]));
            }
            set {
                this["redmine_host"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool show_closed_projects {
            get {
                return ((bool)(this["show_closed_projects"]));
            }
            set {
                this["show_closed_projects"] = value;
            }
        }
    }
}
