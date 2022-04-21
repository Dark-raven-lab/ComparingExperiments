using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        Configuration KeyResult1;
        Configuration KeyResult2;

        public Form1()
        {
            InitializeComponent();
            KeyResult1 = new Configuration();
            KeyResult2 = new Configuration();
        }

        public void Clear()
        {
            KeyResult1.Experiments.Clear();
            KeyResult2.Experiments.Clear();
            richTextBoxLog.Text = "";
            richTextBoxResult_Key1.Text = "";
            richTextBoxResult_Key2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clear();

            if (textBoxKeys1.TextLength < 10)
            {
                Log("Заполните поле 1");
                return;
            }
            if (textBoxKeys2.TextLength < 10)
            {
                Log("Заполните поле 1");
                return;
            }

            Configuration Key1 = new Configuration();
            Configuration Key2 = new Configuration();

            if (!Key1.Parce(textBoxKeys1.Text))
            {
                Log("Ошибка парсинга ключа 1");
                return;
            }

            if (!Key2.Parce(textBoxKeys2.Text))
            {
                Log("Ошибка парсинга ключа 2");
                return;
            }

            KeyResult1 = Key1.Compare(Key2);
            KeyResult2 = Key2.Compare(Key1);

            Print();
        }

        /// <summary>
        /// Записать лог
        /// </summary>
        /// <param name="txt">текст для записи</param>
        /// <param name="append">добавить к существующему</param>
        public void Log(string txt, bool append = false)
        {
            if (append) richTextBoxLog.Text = richTextBoxLog.Text + txt + "\n";
            else richTextBoxLog.Text = txt + "\n";
        }

        public void Print()
        {
            foreach (var item in KeyResult1.Experiments)
            {
                richTextBoxResult_Key1.Text += item.Value.GetString();
            }
            foreach (var item in KeyResult2.Experiments)
            {
                richTextBoxResult_Key2.Text += item.Value.GetString();
            }

            if (KeyResult1.Experiments.Count == 0 && KeyResult2.Experiments.Count == 0)
                Log("Набор параметров в ключах одинаковый", true);
        }

        public class Configuration
        {
            public SortedDictionary<string, Experiment> Experiments = new SortedDictionary<string, Experiment>();

            /// <summary>
            /// Возвращает колличество экспериментов в конфигурации
            /// </summary>
            /// <returns></returns>
            public int GetEperimentsCount() { return Experiments.Count; }

            /// <summary>
            /// Парсит ключ
            /// </summary>
            /// <param name="keys_command_line">ключ с show-variations-cmd</param>
            /// <returns></returns>
            public bool Parce(string keys_command_line)
            {
                if (string.IsNullOrEmpty(keys_command_line)) return false;

                // разделяем по пробелам - ключи отделены пробелами
                string[] rows = keys_command_line.Split(' ');

                if (rows.Length < 1) return false;

                foreach (var row in rows)
                {
                    if (row.Contains("--force-fieldtrials="))
                        ParceExperiments(row);
                }

                if (Experiments.Count == 0)
                {
                    return false;
                }

                foreach (var row in rows)
                {
                    if (row.Contains("features="))
                        ParceFeature(row);
                    else if (row.Contains("force-fieldtrial-params="))
                        ParceFeatureParams(row);
                }

                return true;
            }

            /// <summary>
            /// Создание экспериментов в конфигурации
            /// </summary>
            /// <param name="fieldtrials">строковый параметр содержащий --force-fieldtrials=</param>
            public void ParceExperiments(string fieldtrials)
            {
                // Удаляем ключ в первом элементе
                fieldtrials = fieldtrials.Replace("--force-fieldtrials=", "").Replace("*", "").Trim('"');

                var experiments_string = fieldtrials.Split('/');

                for (int i = 0; i < experiments_string.Length; i = i + 2)
                {
                    if (i + 1 >= experiments_string.Length) continue;
                    Experiments.Add(experiments_string[i].Trim(' '), new Experiment(experiments_string[i], experiments_string[i + 1]));
                }
                //Log("Парсинг экспериментов завершен. Добавлено экспериментов " + Experiments.Count, true);
            }

            /// <summary>
            /// Добавление функциональностей в существующие эксперименты
            /// </summary>
            /// <param name="features_key">строковый параметр содержащий --enable-features=</param>
            public void ParceFeature(string features_key)
            {
                if (!features_key.Contains("="))
                {
                    //Log("Ошибка парсинга features!", true);
                    return;
                }

                bool features_state = features_key.Contains("enable-features");
                int count = 0;
                features_key = features_key.Split('=')[1].Trim('"');

                foreach (var item in features_key.Split(','))
                {
                    string[] keys = item.Split('<');
                    if (keys.Length < 2)
                    {
                        //Log("Ошибка: отсутствует фича/эксперимент в строке " + item, true);
                        continue;
                    }

                    string feature_name = keys[0];
                    string experiment_name = keys[1];

                    if (!Experiments.ContainsKey(experiment_name))
                    {
                        //Log($"Ошибка: отсутствует эксперимент {experiment_name} в списке", true);
                        continue;
                    }
                    Experiments[experiment_name].Features.Add(new Feature(feature_name, features_state));
                    count++;
                }

                //Log($"Парсинг фичей завершен. {(features_state ? "Включенных" : "Выключенных")} фичей {count}", true);
            }

            /// <summary>
            /// Добавление параметров в существующие эксперименты
            /// </summary>
            /// <param name="feature_params">строковый параметр содержащий --force-fieldtrial-params=</param>
            public void ParceFeatureParams(string feature_params)
            {
                if (!feature_params.Contains("--force-fieldtrial-params="))
                {
                    //Log("Ошибка парсинга параметров!", true);
                    return;
                }

                feature_params = feature_params.Split('=')[1].Trim('"');
                var strings = feature_params.Split(',');
                int count = 0;

                foreach (var item in strings)
                {
                    // Aout.1:dialog_enabled/false/first_times/3/level/1/long/90/save_pos_minutes/60/stream/true/then_mode/1
                    var temp = item.Split(':');
                    if (temp.Length < 2)
                    {
                        //Log("Ошибка получения параметров! Ожидаемый формат (exp.value:params1/value/params2/value...). Полученный формат: " + item, true);
                        continue;
                    }

                    var exp_name = temp[0].Split('.')[0];
                    var exp_val = temp[0].Split('.')[1];
                    var exp_params = temp[1];

                    if (!Experiments.ContainsKey(exp_name))
                    {
                        //Log($"Не найден эксперимент {exp_name} для передачи ему параметров {exp_params}", true);
                        continue;
                    }
                    else if (Experiments[exp_name].Value != exp_val)
                    {
                        //Log($"ВНИМАНИЕ! Включен эксперимент {Experiments[exp_name]}/{Experiments[exp_name].Value}, однако параметры заданы для {exp_name}/{exp_val}", true);
                        continue;
                    }

                    var param = exp_params.Split('/');
                    for (int i = 0; i < param.Length; i = i + 2)
                    {
                        if (i + 1 >= param.Length) continue;
                        Experiments[exp_name].Params.Add(new Param(param[i], param[i + 1]));
                        count++;
                    }
                }

                //Log("Парсинг параметров завершен. Добавлено параметров " + count, true);
            }

            /// <summary>
            /// Читает всю конфигурацию и возвращет полную информацию
            /// </summary>
            /// <returns></returns>
            public string GetFullInfo()
            {
                StringBuilder txt = new StringBuilder();
                txt.AppendLine("Список экспериментов:");

                foreach (var item in Experiments)
                {
                    txt.AppendLine(item.Value.GetString());
                }
                return txt.ToString();
            }

            /// <summary>
            /// Возвращает готовый ключ из конфигурации
            /// </summary>
            /// <returns></returns>
            public string GetKeysForCommandLine()
            {
                StringBuilder fieldtrial = new StringBuilder();
                StringBuilder fieldtrial_params = new StringBuilder();
                StringBuilder disable_features = new StringBuilder();
                StringBuilder enable_features = new StringBuilder();

                fieldtrial.Append("--force-fieldtrials=\"");

                foreach (var exp in Experiments.Values)
                {
                    fieldtrial.AppendFormat("{0}/{1}/", exp.Name, exp.Value);

                    if (exp.Params.Count > 0)
                    {
                        if (fieldtrial_params.Length == 0)
                            fieldtrial_params.Append(" --force-fieldtrial-params=\"");
                        else
                            fieldtrial_params.Append(",");

                        fieldtrial_params.AppendFormat("{0}.{1}:", exp.Name, exp.Value);
                        for (int i = 0; i < exp.Params.Count; i++)
                        {
                            var param = exp.Params[i];
                            fieldtrial_params.AppendFormat("{0}/{1}", param.Name, param.Value);
                            if (i < exp.Params.Count - 1)
                                fieldtrial_params.Append("/");
                        }
                    }

                    var features = exp.Features.FindAll(x => x.State == true);
                    
                    if (features.Count > 0)
                    {
                        if (enable_features.Length == 0)
                            enable_features.Append(" --enable-features=\"");
                        else
                            enable_features.Append(",");

                        string txt = "";
                        foreach (var feature in features)
                        {
                            txt += string.Format("{0}<{1},", feature.Name, exp.Name);
                        }
                        
                        enable_features.Append(txt.TrimEnd(','));
                    }

                    features.Clear();
                    features = exp.Features.FindAll(x => x.State == false);
                    
                    if (features.Count > 0)
                    {
                        if (disable_features.Length == 0)
                            disable_features.Append(" --disable-features=\"");
                        else
                            disable_features.Append(",");

                        string txt = "";
                        foreach (var feature in features)
                        {
                            txt+=string.Format("{0}<{1},", feature.Name, exp.Name);
                        }
                        disable_features.Append(txt.TrimEnd(','));
                    }
                }

                fieldtrial.Append('"');

                if (fieldtrial_params.Length > 0)
                    fieldtrial_params.Append('"');

                if (enable_features.Length > 0)
                    enable_features.Append('"');

                if (disable_features.Length > 0)
                    disable_features.Append('"');

                return String.Format("{0}{1}{2}{3}", 
                    fieldtrial.Length > 1 ? fieldtrial.ToString() : "",
                    fieldtrial_params.Length > 1 ? fieldtrial_params.ToString() : "",
                    enable_features.Length > 1 ? enable_features.ToString() : "",
                    disable_features.Length > 1 ? disable_features.ToString() : "");
            }

            /// <summary>
            /// Сравнение конфигураций
            /// </summary>
            /// <param name="config_that">Сравниваемая конфигурация</param>
            /// <returns>Возвращает новую конфигурацию в которой только отличающиеся эксперименты</returns>
            public Configuration Compare(Configuration config_that)
            {
                var result = new Configuration();
                foreach (var item in this.Experiments.Keys)
                {
                    // Не содержится во втором ключе или ключи отличаются
                    if (!config_that.Experiments.ContainsKey(item) || !this.Experiments[item].Equals(config_that.Experiments[item]))
                    {
                        result.Experiments.Add(item, this.Experiments[item]);
                    }
                    // ключи одинаковые
                }

                //Log($"Проверено экспериментов {Experiments.Count}. Отличий {result.Experiments.Count}", true);
                return result;
            }
        }

        public class Experiment
        {
            public string Name { get; set; }
            public string Value { get; set; }

            public List<Feature> Features;

            public List<Param> Params;

            public Experiment(string name, string val)
            {
                Name = name.Trim(' ');
                Value = val.Trim(' ');
                Features = new List<Feature>();
                Params = new List<Param>();
            }

            public string GetString()
            {
                StringBuilder txt = new StringBuilder();
                txt.AppendFormat("Experiment: {0}/{1}\n", Name, Value);

                string enabled = "";
                string disabled = "";

                foreach (var feature in Features)
                {
                    if (feature.State)
                        enabled += "\n\t" + feature.Name;
                    else
                        disabled += "\n\t" + feature.Name;
                }

                if (!string.IsNullOrEmpty(enabled))
                {
                    txt.Append("Features enabled {");
                    txt.AppendLine(enabled);
                    txt.AppendLine("}");
                }

                if (!string.IsNullOrEmpty(disabled))
                {
                    txt.Append("Features disabled {");
                    txt.AppendLine(disabled);
                    txt.AppendLine("}");
                }
                if (Params.Count > 0)
                {
                    txt.AppendLine("Params {");
                    foreach (var param in Params)
                    {
                        txt.AppendFormat("{0}{1}/{2}\n", "\t", param.Name, param.Value);
                    }
                    txt.AppendLine("}");
                }

                return txt.ToString();
            }

            public override bool Equals(object obj)
            {
                return this.Equals(obj as Experiment);
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(this.Name, this.Value);
            }
            private bool Equals(Experiment that)
            {
                if (that == null)
                {
                    return false;
                }
                return object.Equals(this.Name, that.Name) && new HashSet<Feature>(this.Features).SetEquals(that.Features) && new HashSet<Param>(this.Params).SetEquals(that.Params) && this.Value == that.Value;
            }
        }

        public class Feature
        {
            public string Name;
            public bool State;

            public Feature(string name, bool state)
            {
                Name = name.Trim(' ');
                State = state;
            }

            public override bool Equals(object obj)
            {
                return this.Equals(obj as Feature);
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(this.Name, this.State);
            }
            private bool Equals(Feature that)
            {
                if (that == null)
                {
                    return false;
                }
                return object.Equals(this.Name, that.Name) && this.State == that.State;
            }
        }

        public class Param
        {
            public string Name;
            public string Value;

            public Param(string name, string val)
            {
                Name = name.Trim(' ');
                Value = val.Trim(' ');
            }

            public override bool Equals(object obj)
            {
                return this.Equals(obj as Param);
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(this.Name, this.Value);
            }
            private bool Equals(Param that)
            {
                if (that == null)
                {
                    return false;
                }
                return object.Equals(this.Name, that.Name) && this.Value == that.Value;
            }
        }

        private void buttonCopyKey_Key1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(KeyResult1.GetKeysForCommandLine());
            Log("Ключ 1 скопирован в буфер обмена\n", true);
        }

        private void buttonCopyKey_Key2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(KeyResult2.GetKeysForCommandLine());
            Log("Ключ 2 скопирован в буфер обмена\n", true);
        }
    }
}
