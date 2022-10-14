using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BK_Tool
{
    public class SFLDataHandle
    {
        public static string IpString = ConfigurationManager.AppSettings["IpString"];
        public static string PortString = ConfigurationManager.AppSettings["PortString"];

        // ------普通报告------
        string CaseNo = "";  //病例号码
        string patName = "";  //姓名
        DateTime patBirthday;  //出生年月
        string patSex = "";  //性别

        //string patType = ""; //病人类型
        string deptName = ""; //科室
        //string roomNo = ""; //房间
        //string bedNo = ""; //床号
        //string fbType = ""; //费用类型

        string strKey = "";//报告单号
        string sampleNo = "";//样本编号
        DateTime CollectTime;  //采样时间
        DateTime TestTime;  //检验时间
        //string Collect_User = ""; //采集者
        string Diagion = ""; //临床诊断信息

        DateTime RecieveTime;//送检时间
        string SampleSource = "";//样本来源  BLDV”-静脉血“BLDC”-末稍血
        DateTime AuditTime;//审核时间
        string Diagnostic = "";//诊断ID 取值为“HM”，意思为 Hematology，即血液学
        string AuditUser = "";//样本审核者

        string strItemNo = "";//项目ID
        string strResult = "";//项目结果
        string strUnits = "";//单位
        string strRange = "";//参考范围
        string strResultflg = "";

        #region 对截取到的合格拼接串进行HL7协议处理
        /// <summary>
        /// 对截取到的合格拼接串进行HL7协议处理
        /// </summary>
        /// <param name="ib_data">截取到的合格拼接串</param>
        public void ChuLiOneHL7(string ib_data)
        {
            Common common = new Common();
            bool IsUpdate = false;
            strKey = DateTime.Now.ToString("yyyyMMddhhmmss");//报告单号
         
            Maticsoft.Model.report_main_unaudit report_main_unaudit = new Maticsoft.Model.report_main_unaudit();
            Maticsoft.DAL.report_main_unaudit report_main_unauditDal = new Maticsoft.DAL.report_main_unaudit();
            Maticsoft.Model.report_detail_undudit report_detail1_unaudit = new Maticsoft.Model.report_detail_undudit();
            Maticsoft.DAL.report_detail_undudit report_detailDal_unaudit = new Maticsoft.DAL.report_detail_undudit();
            report_main_unaudit.KeyNo_Group = strKey;
            report_main_unaudit.REPORT_ID = strKey;
            report_main_unaudit.INSTRUMENT = "SFL";
            #region 对合格串进行解析
            string[] arrayData = ib_data.Split('\r');
            for (int i = 0; i < arrayData.Length - 1; i++)
            {
                string[] arrayLine = arrayData[i].Split('|');
                switch (arrayLine[0])
                {
                    #region 消息段包含病人的基本信息
                    case "PID":
                        //PID|1||05012006^^^^MR||^张三||19991001000000|男
                        CaseNo = arrayLine[3].Split('^')[0];//病例号码
                        patName = arrayLine[5].Split('^')[1];//姓名
                        patBirthday = common.IsNullCheck(arrayLine[7].ToString());//出生年月
                        patSex = arrayLine[8].ToString();//性别

                        report_main_unaudit.PAT_AGE = common.GetAge(patBirthday, DateTime.Now).Split('|')[0];
                        report_main_unaudit.PAT_AGEUnit = common.GetAge(patBirthday, DateTime.Now).Split('|')[1];
                        report_main_unaudit.PAT_NO = CaseNo;
                        report_main_unaudit.PAT_NAME = patName;
                        report_main_unaudit.PAT_Birthday = patBirthday.ToString("G");
                        if (patSex == "2") { report_main_unaudit.PAT_SEX = "女"; } else { report_main_unaudit.PAT_SEX = "男"; }

                        break;
                    #endregion

                    #region 包含病人的看病信息。
                    case "PV1":
                        //PV1|1|住院|外科^1^2|||||||||||||||||自费  “科室^房间^床号”
                        //patType = arrayLine[2].ToString();//病人类型 => 样本类型

                        report_main_unaudit.SAMPLEType = arrayLine[2].ToString();
                        try
                        {
                            //deptName = arrayLine[3].Split('^')[0];//科室
                            //roomNo = arrayLine[3].Split('^')[1];//房间
                            //bedNo = arrayLine[3].Split('^')[2];//床号
                            report_main_unaudit.BED = arrayLine[3].Split('^')[0];//房间
                        }
                        catch (Exception)
                        {
                        }

                        deptName = arrayLine[20].ToString();//科室

                        //report_main_unaudit. = patType;
                        report_main_unaudit.PAT_DEPTName = deptName;
                        //report_main_unaudit.RoomNo = roomNo;
                        //report_main_unaudit.BedNo = bedNo;
                        //report_main_unaudit.TestName = fbType;

                        break;
                    #endregion

                    #region 仪器信息
                    case "MSH":
                        break;
                    #endregion

                    #region 主要包含检验报告单信息
                    case "OBR":

                        //OBR|1||6-968|01001^99MRC|||2022-06-15 15:52:41|||李佩||||||||||||||HM||||||||produce\r
                        sampleNo = arrayLine[3].ToString();//样本编号
                        CollectTime = common.IsNullCheck(arrayLine[6].ToString());//采样时间
                        TestTime = common.IsNullCheck(arrayLine[7].ToString());//检验时间
                        report_main_unaudit.Send_User = arrayLine[10].ToString();//送检人员                        
                        Diagion = arrayLine[13].ToString();//临床诊断
                        RecieveTime = common.IsNullCheck(arrayLine[14].ToString());//接收时间
                        SampleSource = arrayLine[15].ToString();//样本来源
                        AuditTime = common.IsNullCheck(arrayLine[22].ToString());//审核时间
                        Diagnostic = arrayLine[24].ToString();//诊断ID
                        AuditUser = arrayLine[28].ToString();//审核者
                        report_main_unaudit.TEST_User = arrayLine[32].ToString();
                        report_main_unaudit.SAMPLENO = sampleNo;
                        report_main_unaudit.Diagnosis = Diagion;

                        #region 信息补充

                        report_main_unaudit.RptTypeID = 1;
                        report_main_unaudit.REPORT_NAME = "生化";
                        report_main_unaudit.BARCODE = "01" + DateTime.Now.ToString("yyyymmddhhmmss");
                        report_main_unaudit.REG_TYPE = 0;
                        report_main_unaudit.CREATE_DATE = DateTime.Now;
                        report_main_unaudit.BarcodeTime = DateTime.Now;
                        report_main_unaudit.RegTime = DateTime.Now;
                        report_main_unaudit.OUT_PAT_ID = "-1";
                        report_main_unaudit.TEST_DATE = DateTime.Now;

                        #endregion

                        if (report_main_unauditDal.ExistsBySampleNo(sampleNo))
                        {
                            strKey = report_main_unauditDal.QueryBySampleNo(sampleNo).Rows[0]["REPORT_ID"].ToString();
                            report_main_unaudit.REPORT_ID = strKey;
                            report_main_unaudit.KeyNo_Group = strKey;
                            report_main_unauditDal.Update(report_main_unaudit);
                            IsUpdate = true;
                        }
                        else { report_main_unauditDal.Add(report_main_unaudit); }

                        break;
                    #endregion

                    #region 主要包含各个检验结果参数信息
                    case "OBX":
                        //OBX|7|NM|6690-2^WBC^LN||5.51|10*9/L|4.00-10.00||||F
                        //
                        if (arrayLine[2] == "IS")
                        {
                            if (arrayLine[3].IndexOf("Remark") > 0)
                            {
                                report_main_unaudit.DocMemo = arrayLine[5].ToString();
                                report_main_unauditDal.Update(report_main_unaudit);
                            }
                            if (arrayLine[3].IndexOf("Ref Group") > 0)
                            {
                                report_main_unaudit.RefGroupID = int.Parse(arrayLine[5].ToString());
                                report_main_unauditDal.Update(report_main_unaudit);
                            }

                        }
                        if (arrayLine[3].IndexOf("Histogram") > 0)// 如果循环到这行有Histogram就退出
                        {                        //当第三位为【ED】，代表图片数据为直方图
                            if (arrayLine[2] == "ED")
                            {
                                //获取图片数据串
                                string strImage = arrayLine[5].Split('^')[4];
                                if (arrayLine[3].IndexOf("Binary") >= 0)
                                {
                                    //wf_graph(strImage, arrayLine[3].Split('^')[1]);
                                }
                                else if (arrayLine[3].IndexOf("BMP") >= 0)
                                {
                                    Maticsoft.Model.report_graph report_graph = new Maticsoft.Model.report_graph();
                                    Maticsoft.DAL.report_graph report_graphDal = new Maticsoft.DAL.report_graph();

                                    strImage = common.ImgToBase64String(common.GetImgjpg(strImage));
                                    report_graph.ReportID = strKey;
                                    report_graph.Graph = strImage;

                                    if (!IsUpdate) { report_graphDal.Add(report_graph); }

                                }
                            }
                            else { break; }

                        }
                        strItemNo = arrayLine[3].Split('^')[1];

                        //当第三位为【NM】时，代表普通结果
                        if (arrayLine[2] == "NM")
                        {
                            strResult = arrayLine[5];
                            strUnits = arrayLine[6];
                            strRange = arrayLine[7];
                            strResultflg = arrayLine[8];


                            #region 参考范围
                            if (strRange.IndexOf("-") >= 0)
                            {
                                string[] strRangeList = strRange.Split('-');
                                if (float.Parse(strRangeList[0]) > float.Parse(strResult))
                                {
                                    strResultflg = "↓";//↓↑
                                }
                                else if (float.Parse(strRangeList[1]) < float.Parse(strResult))
                                {
                                    strResultflg = "↑";//↓↑
                                }
                            }
                            else if (strRange.IndexOf(">") >= 0)
                            {
                                if (float.Parse(strRange) < float.Parse(strResult))
                                {
                                    strResultflg = "↓";//↓↑
                                }
                            }
                            else if (strRange.IndexOf("<") >= 0)
                            {
                                if (float.Parse(strRange) > float.Parse(strResult))
                                {
                                    strResultflg = "↑";//↓↑
                                }
                            }
                            #endregion

                            Maticsoft.DAL.item itemDal = new Maticsoft.DAL.item();


                            report_detail1_unaudit.REPORT_ID = strKey;
                            report_detail1_unaudit.KeyNo_Group = strKey;
                            report_detail1_unaudit.RESULT = strResult;
                            report_detail1_unaudit.UNIT = strUnits;
                            report_detail1_unaudit.REFRANGE = strRange;
                            report_detail1_unaudit.Abnormal_flg = strResultflg;
                            report_detail1_unaudit.ITEM_ID = strItemNo;
                            try
                            {
                                report_detail1_unaudit.ITEM_NAME = itemDal.GetList("ItemNo = '" + strItemNo + "'").Tables[0].Rows[0]["ItemName"].ToString();
                                report_detail1_unaudit.ITEM_ENAME = itemDal.GetList("ItemNo = '" + strItemNo + "'").Tables[0].Rows[0]["ItemName"].ToString();
                            }
                            catch (Exception)
                            {                               
                                report_detail1_unaudit.ITEM_NAME = "";
                                report_detail1_unaudit.ITEM_ENAME = "";
                            }

                            if (!IsUpdate) { report_detailDal_unaudit.Add(report_detail1_unaudit); }
                        }
                        break;
                    #endregion
                    default: break;
                }

            }
            #endregion
        }
        #endregion
    }
}
