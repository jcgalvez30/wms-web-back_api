using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Newtonsoft.Json;
using System.ComponentModel;

namespace DataAccess_ActiveDirectory;

public class ObjectUtils {

    #region Dictionary
    public static Dictionary<string, object> generarDiccionario( DataTable poDataTable, int pFila ) {
        DataRow row = poDataTable.Rows[pFila];
        return row.Table.Columns.Cast<DataColumn>().ToDictionary(col => col.ColumnName, col => row.Field<object>(col.ColumnName));
    }
    #endregion
    #region DataTable
    public static DataTable generarDtError( string pMensaje, string pTipoError, int pCodError ) {
        DataTable oDataTable = new DataTable();
        oDataTable.Clear();
        oDataTable.Columns.Add("vCod", typeof(int));
        oDataTable.Columns.Add("vType", typeof(string));
        oDataTable.Columns.Add("vDesc", typeof(string));
        DataRow oFila = oDataTable.NewRow();
        oFila["vCod"] = pCodError;
        oFila["vType"] = pTipoError;
        oFila["vDesc"] = pMensaje;
        oDataTable.Rows.Add(oFila);
        return oDataTable;
    }
    public static DataTable generarDtOk() {
        DataTable oDataTable = new DataTable();
        oDataTable.Clear();
        oDataTable.Columns.Add("vCod", typeof(int));
        oDataTable.Columns.Add("vType", typeof(string));
        oDataTable.Columns.Add("vDesc", typeof(string));
        DataRow oFila = oDataTable.NewRow();
        oFila["vCod"] = 200;
        oFila["vType"] = "RS";
        oFila["vDesc"] = "La operación fue realizada satisfactoriamente.";
        oDataTable.Rows.Add(oFila);
        return oDataTable;
    }
    public static DataTable ordenarDt( DataTable pDataTable, string pColName, string pDirection ) {
        if (pDataTable != null && pDataTable.Columns.Contains(pColName) && pDataTable.Rows.Count > 0
           && (pDirection.ToUpper().Equals("ASC") || pDirection.ToUpper().Equals("DESC"))) {
            pDataTable.DefaultView.Sort = pColName + " " + pDirection;
            pDataTable = pDataTable.DefaultView.ToTable();
        }
        return pDataTable;
    }
    public static DataTable generarDtMensaje( string xidCodigo, string xidTipoMensaje, string pMensaje ) {
        DataTable oDataTable = new DataTable();
        oDataTable.Clear();
        oDataTable.Columns.Add("vCod", typeof(int));
        oDataTable.Columns.Add("vType", typeof(string));
        oDataTable.Columns.Add("vDesc", typeof(string));
        DataRow oFila = oDataTable.NewRow();
        oFila["vCod"] = xidCodigo;
        oFila["vType"] = xidTipoMensaje;
        oFila["vDesc"] = pMensaje;
        oDataTable.Rows.Add(oFila);
        return oDataTable;
    }
    public static DataTable transponerTabla( DataTable poDt ) {
        DataTable oDtResp = new DataTable();
        // Se marca el pivot de la columna 0 (en ambas tablas es el mismo)
        oDtResp.Columns.Add(poDt.Columns[0].ColumnName.ToString());
        // a partir de ahí se empiezan a generar las nuevas columnas
        string vNombreObjeto = "";
        foreach (DataRow oDr in poDt.Rows) {
            vNombreObjeto = oDr[0].ToString();
            oDtResp.Columns.Add(vNombreObjeto);
        }
        // Agregar las filas iterando las columnas
        DataRow oDrFila = null;
        for (int vFila = 1; vFila <= poDt.Columns.Count - 1; vFila++) {
            oDrFila = oDtResp.NewRow();
            // transponer Cabeceras y luego los valores
            oDrFila[0] = poDt.Columns[vFila].ColumnName.ToString();
            for (int vCol = 0; vCol <= poDt.Rows.Count - 1; vCol++) {
                string colValue = poDt.Rows[vCol][vFila].ToString();
                oDrFila[vCol + 1] = colValue;
            }
            oDtResp.Rows.Add(oDrFila);
        }
        return oDtResp;
    }
    public static DataTable generarDT( List<KeyValuePair<string, string>> pCampos ) {
        DataTable dt = new DataTable();
        foreach (KeyValuePair<string, string> columna in pCampos)
            dt.Columns.Add(columna.Key.ToString());
        DataRow row = dt.NewRow();
        foreach (KeyValuePair<string, string> columna in pCampos)
            row[columna.Key.ToString()] = columna.Value.ToString();
        dt.Rows.Add(row);
        return dt;
    }
    public static DataTable ConvertToDataTable<T>( IList<T> data ) {
        PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
        DataTable table = new DataTable();
        foreach (PropertyDescriptor prop in properties)
            table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
        foreach (T item in data) {
            DataRow row = table.NewRow();
            foreach (PropertyDescriptor prop in properties)
                row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
            table.Rows.Add(row);
        }
        return table;
    }
    #endregion
    #region DataSet
    public static DataSet generarDsError( string pMensaje, string pTipoError, int pCodError ) {
        DataSet oDataSet = new DataSet();
        DataTable oDataTable = generarDtError(pMensaje, pTipoError, pCodError);
        oDataSet.Tables.Add(oDataTable);
        return oDataSet;
    }
    public static DataSet generarDsOk() {
        DataSet oDataSet = new DataSet();
        DataTable oDataTable = generarDtOk();
        oDataSet.Tables.Add(oDataTable);
        return oDataSet;
    }
    public static DataSet generarDsMensaje( string xidCodigo, string xidTipoMensaje, string pMensaje ) {
        DataSet oDataSet = new DataSet();
        DataTable oDataTable = generarDtMensaje(xidCodigo, xidTipoMensaje, pMensaje);
        oDataSet.Tables.Add(oDataTable);
        return oDataSet;
    }
    public static DataSet parseJsonToDs( string pData, List<string[]> pColumnas ) {
        DataSet oDs = new DataSet();
        DataTable oDtData = null;
        DataTable oDtLength = null;
        DataRow oDrData = null;
        DataRow oDrLength = null;
        try {
            dynamic vDynData = JsonConvert.DeserializeObject(pData);
            oDtData = generarDtMensaje("" + vDynData[0]["data"]["error"]["xidError"], "" + vDynData[0]["data"]["error"]["xidTipoError"], "" + vDynData[0]["data"]["error"]["msjError"]);
            oDs.Tables.Add(oDtData);
            string[] vColumna;
            if ((vDynData[0]["data"]["length"]) > 0) {
                oDtLength = new DataTable();
                oDtLength.Columns.Add("cantFilas", typeof(int));
                oDs.Tables.Add(oDtLength);
                int vFila = 0;
                foreach (dynamic vDynObj in vDynData[0]["data"]["objects"]) {
                    vColumna = pColumnas[vFila];
                    oDtData = new DataTable();

                    oDrLength = oDtLength.NewRow();
                    oDrLength["cantFilas"] = vDynData[0]["data"]["objects"][vDynObj.Name]["length"];
                    oDtLength.Rows.Add(oDrLength);

                    foreach (string vCampo in vColumna) {
                        oDtData.Columns.Add(vCampo, typeof(string));
                    }

                    foreach (dynamic vDynRow in vDynData[0]["data"]["objects"][vDynObj.Name]["data"]) {
                        oDrData = oDtData.NewRow();
                        foreach (string vCampo in vColumna) {
                            oDrData[vCampo] = vDynRow[vCampo];
                        }
                        oDtData.Rows.Add(oDrData);
                    }
                    oDs.Tables.Add(oDtData);
                    vFila++;
                }
            }
        } catch (Exception ex) {
            oDs = generarDsMensaje("0", "ER", ex.Message);
        }
        return oDs;
    }
    public static DataSet agregarJsonMensajeDS( DataSet oDs ) {
        List<KeyValuePair<string, string>> pCampos = new List<KeyValuePair<string, string>>();
        pCampos.Add(new KeyValuePair<string, string>("vCod", "200"));
        pCampos.Add(new KeyValuePair<string, string>("vType", "RS"));
        pCampos.Add(new KeyValuePair<string, string>("vDesc", "OK"));
        DataSet ds = new DataSet();
        int cont = 1;
        DataTable dtError = new DataTable();
        foreach (KeyValuePair<string, string> columna in pCampos)
            dtError.Columns.Add(columna.Key.ToString());
        DataRow row = dtError.NewRow();
        if (oDs.Tables[0].Columns[0].ColumnName == "vCod") {
            int temp = 0;
            foreach (KeyValuePair<string, string> columna in pCampos) {
                row[columna.Key.ToString()] = oDs.Tables[0].Rows[0].ItemArray[temp].ToString();
                temp++;
            }
        } else {
            foreach (KeyValuePair<string, string> columna in pCampos)
                row[columna.Key.ToString()] = columna.Value.ToString();
        }
        dtError.Rows.Add(row);
        ds.Tables.Add(dtError);
        foreach (DataTable tabla in oDs.Tables) {
            cont++;
            DataTable dt = new DataTable();
            dt = tabla.Copy();
            dt.TableName = string.Concat("Table", cont);
            ds.Tables.Add(dt);
        }
        return ds;
    }
    public static DataSet agregarJsonMensajeDS( DataSet oDs, string vCod, string vType, string vDesc ) {
        List<KeyValuePair<string, string>> pCampos = new List<KeyValuePair<string, string>>();
        pCampos.Add(new KeyValuePair<string, string>("vCod", vCod));
        pCampos.Add(new KeyValuePair<string, string>("vType", vType));
        pCampos.Add(new KeyValuePair<string, string>("vDesc", vDesc));
        DataSet ds = new DataSet();
        int cont = 1;
        DataTable dtError = new DataTable();
        foreach (KeyValuePair<string, string> columna in pCampos)
            dtError.Columns.Add(columna.Key.ToString());
        DataRow row = dtError.NewRow();
        if (oDs.Tables[0].Columns[0].ColumnName == "vCod") {
            int temp = 0;
            foreach (KeyValuePair<string, string> columna in pCampos) {
                row[columna.Key.ToString()] = oDs.Tables[0].Rows[0].ItemArray[temp].ToString();
                temp++;
            }
        } else {
            foreach (KeyValuePair<string, string> columna in pCampos)
                row[columna.Key.ToString()] = columna.Value.ToString();
        }
        dtError.Rows.Add(row);
        ds.Tables.Add(dtError);
        foreach (DataTable tabla in oDs.Tables) {
            cont++;
            DataTable dt = new DataTable();
            dt = tabla.Copy();
            dt.TableName = string.Concat("Table", cont);
            ds.Tables.Add(dt);
        }
        return ds;
    }
    #endregion
    #region DataRow
    public static DataRow generarDR( List<KeyValuePair<string, string>> pCampos, DataTable pDT ) {
        DataRow row = pDT.NewRow();
        foreach (KeyValuePair<string, string> columna in pCampos)
            row[columna.Key.ToString()] = columna.Value == null ? null : columna.Value.ToString();
        return row;
    }
    #endregion
    #region List<int>
    public static List<int> listarIndices( string pstring, string pValue ) {
        if (string.IsNullOrEmpty(pValue))
            throw new ArgumentException("La cadena de caracteres no puede estar vacía", "value");
        List<int> vIndices = new List<int>();
        for (int indice = 0; ; indice += pValue.Length) {
            indice = pstring.IndexOf(pValue, indice);
            if (indice == -1)
                return vIndices;
            vIndices.Add(indice);
        }
    }
    #endregion
}
