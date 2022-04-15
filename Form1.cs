using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

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
            richTextBoxResult_Key1.Text += "";
            richTextBoxResult_Key2.Text += "";
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

            int count = 0;
            foreach (var item in Key1.Experiments.Values)
            {
                Experiment obj2 = null;
                if (Key2.Experiments.ContainsKey(item.Name))
                {
                    obj2 = Key2.Experiments[item.Name];
                }

                if (Equals(item, obj2))
                {
                    continue;
                }

                count++;
                Log($"{item.Name} отличается\n", true);
                LogExperiments(item, obj2);
            }

            if (count == 0)
                Log("Отличий в ключах не обнаружено");
            else
                Log($"Отличий обнаружено {count}");

        }

        public void Log(string txt, bool append = false)
        {
            if (append) richTextBoxLog.Text = txt + richTextBoxLog.Text;
            else richTextBoxLog.Text = txt;
        }

        public void LogExperiments(Experiment exp1, Experiment exp2)
        {
            richTextBoxResult_Key1.Text += exp1 != null ? exp1.GetString() : $"Отсутствует {exp2.Name}\n";
            richTextBoxResult_Key2.Text += exp2 != null ? exp2.GetString() : $"Отсутствует {exp1.Name}\n";
            if (exp1 != null)
                KeyResult1.Experiments.Add(exp1.Name, exp1);

            if (exp2 != null)
                KeyResult2.Experiments.Add(exp2.Name, exp2);
        }

        public class Configuration
        {
            public SortedDictionary<string, Experiment> Experiments = new SortedDictionary<string, Experiment>();

            public int GetEperimentsCount() { return Experiments.Count; }

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
                Console.WriteLine("Парсинг экспериментов завершен. Добавлено экспериментов " + Experiments.Count);
            }

            public void ParceFeature(string features_key)
            {
                if (!features_key.Contains("="))
                {
                    Console.WriteLine("Ошибка парсинга features!");
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
                        Console.WriteLine("Ошибка: отсутствует фича/эксперимент в строке " + item);
                        continue;
                    }

                    string feature_name = keys[0];
                    string experiment_name = keys[1];

                    if (!Experiments.ContainsKey(experiment_name))
                    {
                        Console.WriteLine("Ошибка: отсутствует эксперимент {0} в списке ", experiment_name);
                        continue;
                    }
                    Experiments[experiment_name].Features.Add(new Feature(feature_name, features_state));
                    count++;
                }

                Console.WriteLine("Парсинг фичей завершен. {0} фичей {1}", features_state ? "Включенных" : "Выключенных", count);
            }

            public void ParceFeatureParams(string feature_params)
            {
                if (!feature_params.Contains("--force-fieldtrial-params="))
                {
                    Console.WriteLine("Ошибка парсинга параметров!");
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
                        Console.WriteLine("Ошибка! Ожидаемый формат (exp.value:params1/value/params2/value...). Полученный формат: " + item);
                        continue;
                    }

                    var exp_name = temp[0].Split('.')[0];
                    var exp_val = temp[0].Split('.')[1];
                    var exp_params = temp[1];

                    if (!Experiments.ContainsKey(exp_name))
                    {
                        Console.WriteLine("Не найден эксперимент {0} для передачи ему параметров {1}", exp_name, exp_params);
                        continue;
                    }
                    else if (Experiments[exp_name].Value != exp_val)
                    {
                        Console.WriteLine("ВНИМАНИЕ! Включен эксперимент {0}/{1}, однако параметры заданы для {2}/{3}", Experiments[exp_name], Experiments[exp_name].Value, exp_name, exp_val);
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

                Console.WriteLine("Парсинг параметров завершен. Добавлено параметров " + count);
            }

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

                        foreach (var feature in features)
                        {
                            enable_features.AppendFormat("{0}<{1}", feature.Name, exp.Name);
                        }
                    }

                    features.Clear();
                    features = exp.Features.FindAll(x => x.State == false);
                    
                    if (features.Count > 0)
                    {
                        if (disable_features.Length == 0)
                            disable_features.Append(" --disable-features=\"");
                        else
                            disable_features.Append(",");

                        foreach (var feature in features)
                        {
                            disable_features.AppendFormat("{0}<{1}", feature.Name, exp.Name);
                        }
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
