using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BK_Tool
{
    public class TDDBDataHandle
    {
        // ------普通报告------
        string patSex = "";  //性别

        string strKey = "";//报告单号

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
            Maticsoft.DAL.report_detail_undudit report_detailDal_unauditDal = new Maticsoft.DAL.report_detail_undudit();

            Maticsoft.Model.samplemain samplemain = new Maticsoft.Model.samplemain();
            Maticsoft.DAL.samplemain samplemainDal = new Maticsoft.DAL.samplemain();

            report_main_unaudit.KeyNo_Group = strKey;
            report_main_unaudit.REPORT_ID = strKey;
            report_main_unaudit.INSTRUMENT = "TDDB";
            #region 对合格串进行解析
            string[] arrayData = ib_data.Split('\r');
            for (int i = 0; i < arrayData.Length - 1; i++)
            {
                string[] arrayLine = arrayData[i].Split('|');
                switch (arrayLine[0])
                {
                    #region 消息段包含病人的基本信息
                    case "PID":
                        //PID|3731|||||||M|||||||||||||||||1||||||

                        report_main_unaudit.PAT_IN_HOS_ID = arrayLine[2].ToString();
                        report_main_unaudit.PAT_NO = arrayLine[3].ToString();
                        report_main_unaudit.BED = arrayLine[4].ToString();
                        report_main_unaudit.PAT_NAME = arrayLine[5].ToString();
                        if (arrayLine[6].ToString() != "")
                        {
                            report_main_unaudit.PAT_DEPTName = arrayLine[6].ToString().Split('^')[0];
                            report_main_unaudit.ROOM = arrayLine[6].ToString().Split('^')[1];
                        }
                        report_main_unaudit.PAT_Birthday = common.IsNullCheck(arrayLine[7].ToString()).ToString("G");
                        patSex = arrayLine[8].ToString();//性别
                        if (patSex == "M") { report_main_unaudit.PAT_SEX = "男"; } else if (patSex == "F") { report_main_unaudit.PAT_SEX = "女"; } else { report_main_unaudit.PAT_SEX = "未知"; }
                        report_main_unaudit.BloodType = arrayLine[9].ToString();
                        report_main_unaudit.Address = arrayLine[11].ToString();
                        report_main_unaudit.Telephone = arrayLine[13].ToString();
                        report_main_unaudit.DocMemo = arrayLine[26].ToString();
                        report_main_unaudit.PAT_AGE = common.GetAge(common.IsNullCheck(arrayLine[7].ToString()), DateTime.Now).Split('|')[0];
                        report_main_unaudit.PAT_AGEUnit = common.GetAge(common.IsNullCheck(arrayLine[7].ToString()), DateTime.Now).Split('|')[1];

                        break;
                    #endregion

                    //#region 包含病人的看病信息。
                    //case "PV1":
                    //    //PV1|1|住院|外科^1^2|||||||||||||||||自费  “科室^房间^床号”
                    //    //patType = arrayLine[2].ToString();//病人类型 => 样本类型
                    //    report_main.SampleType = arrayLine[2].ToString();
                    //    try
                    //    {
                    //        //deptName = arrayLine[3].Split('^')[0];//科室
                    //        //roomNo = arrayLine[3].Split('^')[1];//房间
                    //        //bedNo = arrayLine[3].Split('^')[2];//床号
                    //        bedNo = arrayLine[3].Split('^')[0];//房间
                    //    }
                    //    catch (Exception)
                    //    {
                    //    }

                    //    fbType = arrayLine[20].ToString();//费别

                    //    report_main.PatType = patType;
                    //    report_main.PatDept = deptName;
                    //    report_main.RoomNo = roomNo;
                    //    report_main.BedNo = bedNo;
                    //    report_main.TestName = fbType;

                    //    break;
                    //#endregion

                    #region 仪器信息
                    case "MSH":
                        break;
                    #endregion

                    #region 主要包含检验报告单信息
                    case "OBR":
                        //OBR|3731|Invalid0056|3731|BIOBASE^BK-PA120|N|20221012171000|20220921200943||||||||1|||0||||20221012171000||||||||||||||||||||||||||
                        report_main_unaudit.BARCODE = arrayLine[2].ToString();
                        report_main_unaudit.SAMPLENO = arrayLine[3].ToString();
                        if (arrayLine[3].ToString() == "Y")
                        {
                            report_main_unaudit.FALG_Emergency = 1;
                        }
                        else { report_main_unaudit.FALG_Emergency = 0; }

                        report_main_unaudit.BarcodeTime = common.IsNullCheck(arrayLine[6].ToString());

                        report_main_unaudit.RegTime = common.IsNullCheck(arrayLine[7].ToString());


                        report_main_unaudit.Diagnosis = arrayLine[13].ToString();

                        report_main_unaudit.RegTime = common.IsNullCheck(arrayLine[14].ToString());
                        if (arrayLine[15].ToString() != "")
                        {
                            if (arrayLine[15].ToString() == "1") { report_main_unaudit.SAMPLEType = "静脉血"; }
                            else if (arrayLine[15].ToString() == "2") { report_main_unaudit.SAMPLEType = "预稀释"; }
                            else if (arrayLine[15].ToString() == "3") { report_main_unaudit.SAMPLEType = "末梢血"; }
                            else if (arrayLine[15].ToString() == "4") { report_main_unaudit.SAMPLEType = "血清"; }
                        }

                        report_main_unaudit.Send_User = arrayLine[16].ToString();

                        report_main_unaudit.DoctorName = arrayLine[20].ToString();
                        report_main_unaudit.TEST_User = arrayLine[20].ToString();
                        report_main_unaudit.PAT_DEPTName = arrayLine[21].ToString();
                        report_main_unaudit.RptTypeID = 2;
                        report_main_unaudit.REPORT_NAME = "特定蛋白";
                        report_main_unaudit.INSTRUMENT = "TDDB";
                        report_main_unaudit.REG_TYPE = 0;
                        report_main_unaudit.CREATE_DATE = DateTime.Now;
                        report_main_unaudit.OUT_PAT_ID = "-1";


                        if (report_main_unauditDal.ExistsByBarcode(report_main_unaudit.BARCODE))
                        {
                            strKey = report_main_unauditDal.QueryByBarcode(report_main_unaudit.BARCODE).Rows[0]["REPORT_ID"].ToString();
                            report_main_unaudit.REPORT_ID = strKey;
                            report_main_unaudit.KeyNo_Group = strKey;
                            report_main_unauditDal.Update(report_main_unaudit);
                            IsUpdate = true;
                        }
                        else { report_main_unauditDal.Add(report_main_unaudit); }


                        samplemain.BARCODE = arrayLine[2].ToString();
                        samplemain.CREAT_TIME = common.IsNullCheck(arrayLine[6].ToString());
                        samplemain.EXAM_TIME = common.IsNullCheck(arrayLine[7].ToString());
                        samplemain.COLLECT_USER_NAME = arrayLine[10].ToString();
                        samplemain.COLLECT_USER_NAME = arrayLine[16].ToString();
                        samplemain.CREAT_DEPT_NAME = arrayLine[17].ToString();
                        samplemain.EXAM_OPERATOR_NAME = arrayLine[20].ToString();
                        samplemain.RECEIVE_TIME = common.IsNullCheck(arrayLine[14].ToString());
                        samplemain.EXAM_TIME = common.IsNullCheck(arrayLine[14].ToString());


                        #region 样本信息补充
                        samplemain.REPORT_TYPE = "2";
                        samplemain.REPORT_NAME = "特定蛋白";
                        samplemain.REG_TYPE = "0";
                        samplemain.OUT_PAT_ID = "-1";
                        samplemain.PAT_ID = "-1";
                        samplemain.PAT_NAME = report_main_unaudit.PAT_NAME;
                        samplemain.PAT_SEX = report_main_unaudit.PAT_SEX;
                        samplemain.PAT_AGE = report_main_unaudit.PAT_AGE + report_main_unaudit.PAT_AGEUnit;
                        samplemain.ROOM = report_main_unaudit.ROOM;
                        samplemain.BED = report_main_unaudit.BED;
                        samplemain.PAT_NO = report_main_unaudit.PAT_NO;

                        #endregion
                        if (samplemainDal.Exists(samplemain.BARCODE))
                        {
                            samplemainDal.Update(samplemain);
                        }
                        else { samplemainDal.Add(samplemain); }

                        break;
                    #endregion

                    #region 主要包含各个检验结果参数信息
                    case "OBX":
                        //if (arrayLine[2] == "IS")
                        //{
                        //    if (arrayLine[3].IndexOf("Remark") > 0)
                        //    {
                        //        report_main.Demo = arrayLine[5].ToString();
                        //        report_mainDal.Update(report_main);
                        //    }
                        //}
                        //if (arrayLine[3].IndexOf("Histogram") > 0)// 如果循环到这行有Histogram就退出
                        //{                        //当第三位为【ED】，代表图片数据为直方图
                        //    if (arrayLine[2] == "ED")
                        //    {
                        //        //获取图片数据串
                        //        string strImage = arrayLine[5].Split('^')[4];
                        //        if (arrayLine[3].IndexOf("Binary") >= 0)
                        //        {
                        //            //wf_graph(strImage, arrayLine[3].Split('^')[1]);
                        //        }
                        //        else if (arrayLine[3].IndexOf("BMP") >= 0)
                        //        {
                        //            Maticsoft.Model.report_graph report_graph = new Maticsoft.Model.report_graph();
                        //            Maticsoft.DAL.report_graph report_graphDal = new Maticsoft.DAL.report_graph();

                        //            strImage = common.ImgToBase64String(common.GetImgjpg(strImage));
                        //            report_graph.ReportID = strKey;
                        //            report_graph.Graph = strImage;

                        //            if (!IsUpdate) { report_graphDal.Add(report_graph); }

                        //        }
                        //    }
                        //    else { break; }

                        //}

                        //OBX|5105|NM|2|SAA|5.00|mg/L|0.00-10.00|N|||F||5.00|20221012171000||||
                        strItemNo = arrayLine[3].Split('^')[0];

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
                            report_detail1_unaudit.REPORT_ID = strKey;
                            report_detail1_unaudit.KeyNo_Group = strKey;
                            report_detail1_unaudit.ITEM_ID = strItemNo;
                            report_detail1_unaudit.RESULT = strResult;
                            report_detail1_unaudit.UNIT = strUnits;
                            report_detail1_unaudit.REFRANGE = strRange;
                            report_detail1_unaudit.Abnormal_flg = strResultflg;
                            report_detail1_unaudit.ITEM_NAME = arrayLine[4];
                            report_detail1_unaudit.ITEM_ENAME = arrayLine[4];
                            report_detail1_unaudit.RESLT_TIME = common.IsNullCheck(arrayLine[14].ToString());

                            if (!IsUpdate) { report_detailDal_unauditDal.Add(report_detail1_unaudit); }
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
