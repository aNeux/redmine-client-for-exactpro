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
        public bool ask_before_exiting {
            get {
                return ((bool)(this["ask_before_exiting"]));
            }
            set {
                this["ask_before_exiting"] = value;
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
        public bool encryption_enabled {
            get {
                return ((bool)(this["encryption_enabled"]));
            }
            set {
                this["encryption_enabled"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool background_updater_enabled {
            get {
                return ((bool)(this["background_updater_enabled"]));
            }
            set {
                this["background_updater_enabled"] = value;
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
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool background_updater_notify_about_projects {
            get {
                return ((bool)(this["background_updater_notify_about_projects"]));
            }
            set {
                this["background_updater_notify_about_projects"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool background_updater_notify_about_issues {
            get {
                return ((bool)(this["background_updater_notify_about_issues"]));
            }
            set {
                this["background_updater_notify_about_issues"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool background_updater_play_notification_sound {
            get {
                return ((bool)(this["background_updater_play_notification_sound"]));
            }
            set {
                this["background_updater_play_notification_sound"] = value;
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
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool show_closed_projects {
            get {
                return ((bool)(this["show_closed_projects"]));
            }
            set {
                this["show_closed_projects"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool show_projects_without_current_user {
            get {
                return ((bool)(this["show_projects_without_current_user"]));
            }
            set {
                this["show_projects_without_current_user"] = value;
            }
        }
    }
}
