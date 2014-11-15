﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class views_ContratoProspecto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] == null) //Si el usuario es nulo es porque ha caducado la sesión
        {
            Response.Redirect("~/Login.aspx"); //redirecciona a login
        }
        chbxAceptar.Checked = false;
        if (!IsPostBack)
        {
            lblTitlePrincipal.Text = "CONTRATO KISEM";
            chbxAceptar.Checked = false;
            llenaContrato();
        }
    }

    protected void lnkContrato_Click(object sender, EventArgs e)
    {
        Response.ContentType = "Application/pdf";
        Response.AppendHeader("Content-Disposition", "attachment; filename=CONTRATO_DE_ASOCIADOS_KISEM.pdf");
        Response.TransmitFile(Server.MapPath("~/Documents/CONTRATO_DE_ASOCIADOS_KISEM.pdf"));
        Response.End();
    }

    protected void chbxAcepto_CheckedChanged(object sender, EventArgs e)
    {
        Response.Redirect("~/views/AltaProspecto.aspx");
    }

    protected void llenaContrato()
    {
        txtContrato.Text = "CONTRATO DE DISTRIBUCION MERCANTIL INDEPENDIENTE QUE CELEBRAN POR UNA PARTE COMO PROVEEDOR “KISEM DE MEXICO, S. DE R.L. DE C.V.”, A QUIEN EN LO SUCESIVO SE LE DENOMINARA “KÍSEM” o “SISTEMA DE PROSPERIDAD KISEM” Y POR LA OTRA PARTE EL FIRMANTE (DE LA SOLICITUD EN EL ANVERSO DE ESTE CONTRATO) COMO COMPRADOR Y DISTRIBUIDOR A QUIEN EN LO SUCESIVO SE LE DENOMINARÁ “ASOCIADO”, QUIENES MANIFIESTAN ESTAR DE ACUERDO EN SUJETARSE A LAS SIGUIENTES DECLARACIONES Y CLÁUSULAS. \n\n"
                + "I.- D E C L A R A C I O N E S:\n\n"
                + "1.-'KISEM' Establece a través de su representante legal:\n\n"
                + "A) Que es una Sociedad de Responsabilidad Limitada constituida legalmente mediante Escritura Pública No. 25,397 el 12 de AGOSTO del 2010, ante la fe del Lic. Enrique Javier Olvera Villaseñor, Titular de la Notaria Público No. 21 de la ciudad de Querétaro, e inscrito en el Registro Público de la Propiedad y del Comercio bajo el folio mercantil electrónico No. 40702-1, y que la celebración de este contrato queda dentro de su objeto social, rigiéndose con las leyes mercantiles de la Republica Mexicana con domicilio en la ciudad de Querétaro, Querétaro, con registro federal de contribuyentes KME-100812-977 y que se dedica además de otras actividades a la venta, distribución y comercialización de diferentes productos de origen natural, alimenticio, cosmético y educativo, de los que de ahora en adelante se les denominará 'PRODUCTOS KISEM'.\n"
                + "B) Que ha desarrollado un plan de mercadeo de venta directa basado en redes de contacto persona a persona, con un sistema de ganancia o compensación de varios niveles comúnmente denominado Multinivel o Redes de Mercadeo, cuyas características se especifican a detalle en el Plan de Negocio proporcionado por KISEM, mismo que forma parte integrante del presente contrato.\n"
                + "C) Para efectos de este contrato señala como domicilio de KISEM el ubicado en Av. 5 de Febrero No. 305 Int. 207-B Colonia La Capilla, CP 76170 en Querétaro, Querétaro.\n\n"
                + "2.- El “Asociado” establece que:\n\n"
                + "A) Es una persona física sin ningún impedimento y con capacidad legal para suscribir el presente contrato y está dispuesto a realizar en el momento requerido los trámites gubernamentales y fiscales correspondientes para el buen funcionamiento de su negocio y que se encuentra inscrito ante el Servicio de Administración Tributaria con el Registro Federal de Contribuyentes _________________, o, en su defecto, se obliga a darse de alta y proporcionar a KISEM su clave de Registro Federal de Contribuyentes.\n"
                + "B) Que ha solicitado a KISEM en su calidad de comerciante independiente, ser “Asociado” no exclusivo, ni subordinado, sin perjuicio de otras actividades comerciales que realiza hoy en día y que cuenta con la experiencia, elementos materiales y humanos propios, así como con las relaciones necesarias para dedicarse de manera independiente a la promoción, distribución y comercio de los Productos KISEM.\n"
                + "C) Que llevará a cabo sus actividades de promoción, distribución y comercio de los productos KISEM de manera independiente, no subordinada, sin derechos exclusivos de ninguna naturaleza en territorio alguno, y sin perjuicio de otras actividades comerciales o de otra índole que efectúa hoy día, ya que como comerciante independiente no está en situación de dependencia de KISEM, ni directa ni indirectamente, en virtud de las relaciones comerciales objeto de este contrato, Entendiéndose que no hay ninguna relación laboral directa o indirecta con KISEM DE MEXICO, S. DE R.L. DE C.V., ni con los promotores, consumidores, distribuidores, subdistribuidores, comisionistas, representantes, afiliados, patrocinadores o asociados a “KISEM”, y que podrá trabajar libremente como empresario independiente, sin sujetarse a un horario o lugar preestablecido por “KISEM” quedando a su libre decisión y conveniencia el hacerlo o no sin que esté obligado a presentar algún reporte. Salvo informes del avance de trabajo y crecimiento de la organización que están desarrollando con el equipo de trabajo así como los líderes de la empresa.\n"
                + "D) Que ha leído y revisado el total de las cláusulas y condiciones especificadas de esta solicitud, así como el Plan de Negocio KISEM, y reconoce que forma parte integrante del presente contrato y está de acuerdo con ambos documentos.\n\n"
                + "3.- Y siendo la voluntad de ambas partes celebrar el presente contrato, están de acuerdo en que se otorgará conforme a las siguientes\n\n"
                + "II.- C L Á U S U L A S:"
                + "PRIMERA: KISEM acepta inscribir al “Asociado” en su registro de Distribuidores Independientes de KISEM, el “Asociado” tiene el derecho no exclusivo de comprar los productos para su uso personal o para su venta si así lo desea, también podrá promover el 'Sistema de Prosperidad Kísem'\n"
                + "SEGUNDA: EL 'Asociado' habiendo llenado todos los requisitos y cumpliendo el reglamento de KISEM podrá adquirir los productos al precio establecido de venta para los Asociados según lo establezca KISEM en su política de ventas.\n"
                + "TERCERA: KISEM garantiza una buena calidad en sus productos y una satisfacción total, más no sobre los efectos que ellos produzcan sobre la persona, ya que cada organismo es diferente.\n"
                + "El “Asociado” consumidor deberá ante todo ser honesto y en ningún caso deberá mentir a los nuevos “Asociados” mencionando datos o información incorrecta que pueda mal entenderse por el cliente. El “Asociado” deberá al promover los productos, mencionar que son estrictamente de naturaleza alimentaria y nutricional y no deberá hacer diagnósticos médicos.\n"
                + "En el supuesto caso de que el “Asociado” falsifique información o incumpla el párrafo anterior y algún prospecto o nuevo “Asociado” presente por lo anterior alguna reclamación, será exclusiva cuenta del “Asociado” el atender reclamación comprometiéndose a liberar de cualquier responsabilidad a KISEM.\n"
                + "CUARTA: “KISEM” podrá conceder a sus “Asociados” el pago de regalías y bonos por su buen desempeño en su labor como distribuidores. Los porcentajes de las regalías y los montos de los bonos así como la mecánica y los procedimientos respectivos de otorgamiento de dichas regalías y bonos, se encuentran comprendidas en el Plan de Compensación de “KISEM”.”KISEM” se reserva el derecho de modificar o cambiar en cualquier momento la estructura del plan de mercadotecnia, así como los porcentajes de las regalías y el monto de los bonos manejados en el mismo.\n"
                + "QUINTA: El “Asociado” declara que conoce el Plan de Compensación de KISEM, así como los Productos KISEM o en su caso se compromete a conocerlos suficientemente para poder “recomendar” (tanto los Productos como el Plan de Negocio) a otras personas con honestidad y eficacia. El Distribuidor Independiente percibirá ingresos conforme a lo establecido y previsto en el Plan de Negocio por la distribución de los Productos KISEM al público en general. Se le otorgarán los reembolsos previstos en dicho Plan, los cuales se determinarán tomando como base sus compras directas efectuadas a KISEM, así como las compras de los Asociados que sean parte de su organización o red.\n"
                + "SEXTA: El “Asociado” deberá de hacer los pedidos y depositar el importe correspondiente a esa compra en la cuenta bancaria indicada por “KISEM” del banco que se indique previamente, o bien hacer el pago directamente en alguno de los centros de distribución de “KISEM”. El transporte y los gastos de entrega corren por cuenta del “Asociado”, salvo decisión en contrario.\n"
                + "SÉPTIMA: “KISEM” Tiene el derecho de modificar cualquier producto o suspenderlo en cualquier momento si así fuera necesario, ya sea para obtener alguna mejora o por causa de fuerza mayor. Si el “Asociado” tuviera algún pedido pendiente de recibir del producto modificado o cancelado, ”KISEM” se compromete a surtirle un producto equivalente o en su defecto a reembolsarle el importe.\n"
                + "OCTAVA: “KISEM” le venderá al “Asociado” los Productos KISEM que este requiera, siempre y cuando KISEM los tenga en existencia en sus almacenes, centros de distribución y puntos de venta. El Asociado deberá liquidar totalmente el importe de sus compras en el momento de realizar su pedido. La propiedad y el riesgo de pérdida de los productos adquiridos conforme a este contrato correrán a cargo del Asociado a partir del momento en que éste reciba la compra de productos que haya hecho a KISEM conforme a su pedido.\n"
                + "NOVENA: El “Asociado” deberá hacerse cargo de todos los gastos ocasionados por la promoción de los productos y/o de la capacitación, así como también deberá pagar todos los impuestos inherentes a esta actividad.\n"
                + "DÉCIMA: Los derechos u obligaciones del Asociado que se deriven de este contrato son personales, por lo que no podrán ser cedidos todos o en parte sin el consentimiento previo y por escrito por parte de KISEM. Así como la franquicia, en este caso, es heredable a cualquier persona que el Asociado designe como nuevo propietario de la posición, ya sea mediante testamento o cualquier instrumento legal que el Asociado designe, siempre y cuando el nuevo Asociado cumpla con los requisitos que “KISEM” estipule en el Plan de Negocio para poder seguir siendo acreedor a los pagos generados.\n"
                + "DÉCIMA PRIMERA: El “Asociado” está de acuerdo en que una vez entregado el producto, Kísem no acepta devoluciones.\n"
                + "DECÍMA SEGUNDA: El “Asociado” deberá respetar todos los derechos de propiedad industrial y derechos de autor de “KÍSEM” y de sus filiales. El “Asociado” no podrá utilizar el nombre comercial de “KISEM” o marcas registradas, bajo los cuales se presentan comercialmente los productos, en ningún medio de publicidad, tarjetas de presentación, carteles, folletos vehículos, chequeras o papelería, sin el previo consentimiento por escrito de Kísem.\n"
                + "DÉCIMA TERCERA: El “Asociado” no podrá en ningún momento erigirse como representante, agente, sucursal, empleado, funcionario, vendedor o apoderado de “KISEM”. \n"
                + "DÉCIMA CUARTA: El “Asociado” se compromete a actuar con honestidad, de una manera profesional y ética ante sus prospectos y demás compañeros Asociados de “KÍSEM”, realizando sus actividades siempre en equipo y armonía, de acuerdo con las políticas y ética de “KISEM”. Los Distribuidores no ejecutarán ninguna conducta que pudiera reflejarse negativamente en la imagen de “KISEM” o en la de ningún otro Distribuidor. Los Distribuidores serán corteses y respetuosos con toda persona que contacten, incluyendo al personal de las oficinas corporativas de “KISEM”, y conducirán su negocio de tal forma que se respeten los productos y el profesionalismo de “KISEM” y sus demás Distribuidores. Ningún Distribuidor, bajo ninguna circunstancia, podrá desacreditar o usurpar el nombre de “KISEM” o su reputación al comercializar productos de “KISEM” o apropiarse indebidamente de informaciones confidenciales, registradas o secretos comerciales (incluyendo los nombres y direcciones de Distribuidores) de “KISEM” para su uso personal o el de otras personas. También a cumplir con las responsabilidades de liderazgo que tenga como patrocinador entre las que se encuentran la capacitación, el apoyo y la comunicación con los Distribuidores de mi organización, así como con mi línea ascendente, no hacer declaraciones erróneas acerca de los productos o el Plan de Compensación de “KÍSEM”, No patrocinar o intentar patrocinar directa o indirectamente a ningún Distribuidor de “KÍSEM” en otra compañía de mercadeo en red ni participar en prácticas engañosas o ilegales. De lo contrario se hará efectiva la cláusula de rescisión del contrato, perdiendo con esto los derechos y obligaciones que se contrajo con la empresa por medio de este contrato. En forma específica los distribuidores que ostenten cualquier rango, incluso los distribuidores asociados sin rango, que incurran en prácticas faltas de ética y honestidad, entendiéndose por esto como ejemplo pero sin ser limitativas el hecho de invitar a Asociados o Distribuidores de “KÍSEM” con prácticas engañosas o ilegales, o que hablen mal de “KÍSEM”, asimismo a los distribuidores que ostenten un rango desde Diamante y hasta el rango más alto de la empresa, con el solo de hecho de presentarse ante distribuidores de otra empresa distinta de “KÍSEM”, o tratar de patrocinar Distribuidores Asociados de “KÍSEM” para otra empresa, aún sea sin prácticas faltas de ética y honestidad, sin previo aviso a “KÍSEM” se tomará como una conducta falta de ética y honestidad dando pauta para la rescisión del contrato actual. No realizar comentarios despectivos sobre los productos de la competencia y no hacer declaraciones difamatorias, calumniosas o peyorativas sobre competidores o sobre otros Distribuidores. No emprender actividades que pudieran desprestigiar a la Compañía, a otros Distribuidores o a mí mismo, Ser honesto respecto de los Productos y no realizar afirmaciones sobre los mismos que no figuren o cuenten con el apoyo de publicaciones oficiales de la Compañía. Cumplir con las responsabilidades de liderazgo como Patrocinador a través de la asociación, asistencia a capacitación y otras formas de respaldo a los Distribuidores de la Organización, Acatar correcta y lealmente el Plan de Pagos y los ingresos residuales consignados en el mismo, Respetar todas y cada una de las condiciones del Contrato, Respetar el Patrocinio de los demás Distribuidores y no intentar interferir o alterar dicho Patrocinio, ni realizar afirmaciones despectivas o falsas sobre otros Distribuidores.\n"
                + "DÉCIMA QUINTA: Si durante el ejercicio de sus actividades de distribución y comercialización, el Asociado encuentra personas o clientes interesados en la distribución de Productos KISEM, éste podrá invitarlos a que soliciten a KISEM su incorporación como Asociados. En caso de ser aceptados, éstos últimos pasarán a formar parte de su organización o red de distribución independiente bajo su auspicio o patrocinio, sumándose el volumen de sus compras al volumen de compras del Asociado, conforme a lo establecido en el Plan de Negocio.\n"
                + "DÉCIMA SEXTA: El precio de compra del Asociado será regulado por la lista de precios vigente publicada por KISEM a la fecha de efectuar cada compra, aplicable a Productos y materiales de promoción. KISEM se reserva el derecho de modificar su lista de precios en cualquier momento, entrando en vigor en la fecha que se publique dicho cambio \n"
                + "DÉCIMA SÉPTIMA: KISEM se reserva el derecho de modificar en cualquier momento su Plan de Negocio, hecho que el Distribuidor Independiente acepta y reconoce. En caso que éste último no esté de acuerdo con alguna modificación, tendrá derecho a notificar y solicitar por escrito a KISEM la terminación de este Contrato.\n"
                + "DÉCIMA OCTAVA: La duración de este contrato será indefinida, y podrá darse por terminado a petición de cualquiera de las partes en cualquier momento y sin causa alguna, mediante aviso por escrito proporcionado con 30 días naturales de anticipación, sin responsabilidad alguna para la parte que haya solicitado la terminación, excepto la liquidación de las operaciones pendientes entre ambas partes. En caso que el Asociado dé por terminado este contrato, deberá esperar al menos 6 meses para volver a presentar una nueva solicitud de contrato. La terminación de este contrato podrá hacerse efectiva sin presentar aviso por escrito en caso de que exista algún impedimento o causa de fuerza mayor que obligue o impida a la empresa continuar con sus actividades comerciales. En caso de incumplimiento del Distribuidor Independiente del Plan de Negocio o de cualquiera de sus obligaciones derivadas del presente contrato, KISEM podrá dar por terminado de manera inmediata este contrato mediante aviso por escrito y sin necesidad de declaración judicial. Si el “Asociado” no realizara ninguna operación de compra en un periodo consecutivo de 4 meses, automáticamente se le dará de baja de “KISEM“, pudiendo nuevamente ser inscrito como socio al ser patrocinado por segunda ocasión por su mismo patrocinador o por otro Socio Consumidor, en una nueva posición y nuevo ID, sin embargo perdería la totalidad de sus derechos sobre las regalías y/o bonos que genere su red descendente.\n"
                + "DÉCIMA NOVENA: El “Asociado” acepta de KISEM que se le retengan los impuestos correspondientes al ISR, IVA, etc., derivados de las comisión y/bonificaciones o pagos y demás actos comerciales y de promoción gravables que realice de acuerdo con las disposiciones fiscales vigentes salvo decisión en contrario (por escrito) emitida por el “Asociado”. De acuerdo con lo anterior, comunico mi opción (firmando tal decisión en la última hoja de este contrato) por el régimen fiscal de mis ingresos que recibiré de la empresa Kísem de México, S. de R.L. de C.V., los cuales tendrán el tratamiento de “Actividades Empresariales que se asimilan opcionalmente a salarios” de acuerdo al artículo 110, fracción VI de la Ley de Impuestos sobre la Renta en vigor, Acepto la retención del Impuesto Sobre la Renta que me corresponda de acuerdo a la tabla del Art. 113 de la Ley del ISR en vigor. En caso de que el “Asociado” desee que no le hagan dicha retención, deberá de entregarle a Kísem recibo de honorarios o factura por el valor del pago entregado. Kísem enterará al Servicio de Administración Tributaria, dichos impuestos retenidos entregándole al “Asociado” el comprobante de retención respectivo cuando él así lo solicite.\n"
                + "VIGÉSIMA: El “Asociado” da su consentimiento pleno para que las regalías y/o bonos o premios en efectivo derivadas de su promoción objeto de este contrato, le sean depositados en una cuenta bancaria específica (de acuerdo a las indicaciones de KISEM). Dándose por parte del “Distribuidor” la aceptación de este instrumento de pago como válido, siendo el comprobante de depósito y/o estado de cuenta que el banco le otorgue a “KISEM”, un instrumento válido para todos los efectos legales que correspondan. A dicho depósito se le retendrán los impuestos correspondientes mencionados en el párrafo anterior.\n"
                + "VIGÉSIMA PRIMERA: LEYES Y JURISDICCIÓN: Las partes se regirán por lo dispuesto en éste contrato mercantil y en lo establecido por el Código Civil para el estado de Querétaro. Para todo lo relativo con la interpretación y cumplimiento del presente contrato, las partes se someten expresamente a la jurisdicción de los tribunales de la Ciudad de Querétaro, Querétaro, México, renunciando expresamente a cualquier fuero de domicilio actual o futuro que pudiese corresponderle. De igual manera para todo lo no previsto en este contrato, las partes se sujetan al Plan de Negocio, o en su defecto al Código de Comercio vigente en el estado de Querétaro.\n"
                + "VIGÉSIMA SEGUNDA: Todo aviso o notificación relacionada con este contrato se hará por escrito y será enviado por correo certificado y con porte pagado a los domicilios especificados al inicio del presente contrato, salvo que exista notificación por escrito de cambio de domicilio de cualquiera de las partes. \n"
                + "VIGÉSIMA TERCERA: Si alguna de las cláusulas de este contrato fuera declarada nula, o sin efecto legal mediante sentencia judicial o resolución de autoridad competente, las demás cláusulas no dejarán de tener pleno valor y vigencia. \n"
                + "VIGÉSIMA CUARTA: Bajo protesta de decir verdad, ambas partes manifiestan que el presente contrato y Plan de Negocio carece de vicios como son error, dolo u omisión.\n";

        //txtContrato.Text = "CONTRATO DE DISTRIBUCION MERCANTIL INDEPENDIENTE QUE CELEBRAN POR UNA PARTE COMO PROVEEDOR 'KISEM DE MEXICO, S. DE R.L. DE C.V.', A QUIEN EN LO  SUCESIVO SE LE DENOMINARA 'KÍSEM' o 'SISTEMA DE PROSPERIDAD KISEM' Y POR LA OTRA PARTE EL FIRMANTE (DE LA SOLICITUD EN EL ANVERSO DE ESTE CONTRATO) COMO COMPRADOR Y DISTRIBUIDOR A QUIEN EN LO SUCESIVO SE LE DENOMINARÁ 'ASOCIADO', QUIENES MANIFIESTAN ESTAR DE ACUERDO EN SUJETARSE A LAS SIGUIENTES DECLARACIONES Y CLÁUSULAS. \n\n"
        //+ "I.- D E C L A R A C I O N E S:\n\n"
        //+ "1.-'KISEM' Establece a través  de su representante legal:\n\n"
        //+ "A) Que es una Sociedad de Responsabilidad Limitada constituida legalmente mediante Escritura Pública No. 25,397 el 12 de AGOSTO del 2010, ante la fe del Lic. Enrique Javier Olvera Villaseñor, Titular de la Notaria Público No. 21 de la ciudad de Querétaro, e inscrito en el Registro Público de la Propiedad y del Comercio bajo el folio mercantil electrónico No. 40702-1, y que la celebración de este contrato queda dentro de su objeto social, rigiéndose con las leyes mercantiles de la Republica Mexicana con domicilio en la ciudad de Querétaro, Querétaro, con registro federal de contribuyentes KME-100812-977 y que se dedica además de otras actividades a la venta, distribución y comercialización de diferentes productos de origen natural, alimenticio, cosmético y educativo, de los que de ahora en adelante se les denominará 'PRODUCTOS KISEM'.\n"
        //+ "B) Que ha desarrollado un plan de mercadeo de venta directa basado en redes de contacto persona a persona, con un sistema de ganancia o compensación de varios niveles comúnmente denominado Multinivel o Redes de Mercadeo, cuyas características se especifican a detalle en el Plan de Negocio proporcionado por KISEM, mismo que forma parte integrante del presente contrato.\n"
        //+ "C) Para efectos de este contrato señala como domicilio de KISEM el ubicado en Av. 5 de Febrero No. 305 Int. 207-B Colonia La Capilla, CP 76170 en Querétaro, Querétaro.\n\n"
        //+ "2.- El 'Asociado' establece que:\n\n"
        //+ "A) Es una persona física sin ningún impedimento y con capacidad legal para suscribir el presente contrato y está dispuesto a realizar en el momento requerido los trámites gubernamentales y fiscales correspondientes para el buen funcionamiento de su negocio y que se encuentra inscrito ante el Servicio de Administración Tributaria con el Registro Federal de Contribuyentes  _________________, o, en su defecto, se obliga a darse de alta y proporcionar a KISEM su clave de Registro Federal de Contribuyentes.\n"
        //+ "B) Que ha solicitado a KISEM en su calidad de comerciante independiente, ser 'Asociado' no exclusivo, ni subordinado, sin perjuicio de otras actividades comerciales que realiza hoy en día y que cuenta con la experiencia, elementos materiales y humanos propios, así como con las relaciones necesarias para dedicarse de manera independiente a la promoción, distribución y comercio de los Productos KISEM.\n"
        //+ "C) Que llevará a cabo sus actividades de promoción, distribución y comercio de los Productos KISEM de manera independiente, no subordinada, sin derechos exclusivos de ninguna naturaleza en territorio alguno, y sin perjuicio de otras actividades comerciales o de otra índole que efectúa hoy día, ya que como comerciante independiente no está en situación de dependencia de KISEM, ni directa ni indirectamente, en virtud de las relaciones comerciales objeto de este contrato, Entendiéndose que no hay  ninguna relación laboral directa o indirecta con KISEM DE MEXICO, S. DE R.L. DE C.V., ni con los promotores, consumidores, distribuidores, subdistribuidores, comisionistas, representantes, afiliados, patrocinadores o asociados a 'KISEM', y que podrá trabajar libremente como empresario independiente, sin sujetarse a un horario o lugar preestablecido por 'KISEM' quedando a su libre decisión y conveniencia el hacerlo o no sin que esté obligado a presentar algún reporte.\n"
        //+ "D) Que ha leído y revisado el total de las cláusulas y condiciones especificadas de esta solicitud, así como el Plan de Negocio KISEM, y reconoce que forma parte integrante del presente contrato y está de acuerdo con ambos documentos.\n\n"
        //+ "3.- Y siendo la voluntad de ambas partes celebrar el presente contrato, están de acuerdo en que se otorgará conforme a las siguientes\n\n"
        //+ "II.- C L Á U S U L A S:\n\n"
        //+ "PRIMERA: KISEM acepta inscribir al 'Asociado' en su registro de Distribuidores Independientes de KISEM, el 'Asociado' tiene el derecho no exclusivo de comprar los productos para su uso personal o para su venta si así lo desea, también podrá promover el 'Sistema de Prosperidad Kísem'\n\n"
        //+ "SEGUNDA: EL 'Asociado' habiendo llenado todos los requisitos y cumpliendo el reglamento de KISEM podrá adquirir los productos al precio establecido de venta para los Asociados según lo establezca KISEM en su política de ventas.\n\n"
        //+ "TERCERA: KISEM garantiza una buena calidad en sus productos y una satisfacción total, más no sobre los efectos que ellos produzcan sobre la persona, ya que cada organismo es diferente.\n\n"
        //+ "El 'Asociado' consumidor deberá ante todo ser honesto y en ningún caso deberá mentir a los nuevos 'Asociados' mencionando datos o información incorrecta que pueda mal entenderse por el cliente. El 'Asociado' deberá al promover los productos,  mencionar que son estrictamente de naturaleza alimentaria y nutricional y no deberá hacer  diagnósticos médicos.\n"
        //+ "En el supuesto caso de que el 'Asociado' falsifique información o incumpla el párrafo anterior y algún prospecto o nuevo 'Asociado' presente por lo anterior alguna reclamación, será exclusiva cuenta del 'Asociado' el atender reclamación comprometiéndose a liberar de cualquier responsabilidad a KISEM.\n\n"
        //+ "CUARTA: 'KISEM' podrá conceder a sus 'Asociados' el pago de regalías y bonos por su buen desempeño en su labor como distribuidores. Los porcentajes de las regalías y los montos de los bonos así como la mecánica y los procedimientos respectivos de otorgamiento de dichas regalías y bonos, se encuentran comprendidas en el Plan de Compensación de 'KISEM'.'KISEM' se reserva el derecho de modificar o cambiar en cualquier momento la estructura del plan de mercadotecnia, así como los porcentajes de las regalías y el monto de los bonos manejados en el mismo.\n\n"
        //+ "QUINTA:  El 'Asociado' declara que conoce el Plan de Compensación de KISEM, así como los Productos KISEM o en su caso se compromete a conocerlos suficientemente para poder 'recomendar' (tanto los Productos como el Plan de Negocio) a otras personas con honestidad y eficacia. El Distribuidor Independiente percibirá ingresos conforme a lo establecido y previsto en el Plan de Negocio por la distribución de los Productos KISEM al público en general. Se le otorgarán los reembolsos previstos en dicho Plan, los cuales se determinarán tomando como base sus compras directas efectuadas a KISEM, así como las compras de los Asociados que sean parte de su organización o red.\n\n"
        //+ "SEXTA: El 'Asociado' deberá de hacer los pedidos y depositar el importe correspondiente a esa compra en la cuenta bancaria indicada por 'KISEM' del banco que se indique previamente, o bien hacer el pago directamente en alguno de los centros de distribución de 'KISEM'. El transporte y los gastos de entrega corren por cuenta del 'Asociado', salvo decisión en contrario.\n\n"
        //+ "SÉPTIMA: 'KISEM' Tiene el derecho de modificar cualquier producto a suspenderlo en cualquier momento si así fuera necesario, ya sea para obtener alguna mejora o por causa de fuerza mayor. Si el 'Asociado' tuviera algún pedido pendiente de recibir del producto modificado o cancelado, 'KISEM' se compromete a surtirle un producto equivalente o en su defecto a reembolsarle el importe.\n\n"
        //+ "OCTAVA: 'KISEM' le venderá al 'Asociado' los Productos KISEM que este requiera, siempre y cuando KISEM los tenga en existencia en sus almacenes, centros de distribución y puntos de venta. El Asociado deberá liquidar totalmente el importe de sus compras en el momento de realizar su pedido. La propiedad y el riesgo de pérdida de los productos adquiridos conforme a este contrato correrán a cargo del Asociado a partir del momento en que éste reciba la compra de productos que haya hecho a KISEM conforme a su pedido.\n\n"
        //+ "NOVENA: El 'Asociado' deberá hacerse cargo de todos los gastos ocasionados por la promoción de los productos y/o de la capacitación,  así como también deberá pagar todos los impuestos inherentes a esta actividad.\n\n"
        //+ "DÉCIMA: Los derechos u obligaciones del Asociado que se deriven de este contrato son personales, por lo que no podrán ser cedidos todos o en parte sin el consentimiento previo y por escrito por parte de KISEM. Así como la franquicia, en este caso, es heredable a cualquier persona que el Asociado designe como nuevo propietario de la posición, ya sea mediante testamento o cualquier instrumento legal que el Asociado designe, siempre y cuando el nuevo Asociado cumpla con los requisitos que 'KISEM' estipule en el Plan de Negocio para poder seguir siendo acreedor a los pagos generados.\n\n"
        //+ "DÉCIMA PRIMERA: El 'Asociado' está de acuerdo en que una vez entregado el producto, Kísem no acepta devoluciones.\n\n"
        //+ "DECÍMA SEGUNDA: El 'Asociado' deberá respetar todos los derechos de propiedad industrial y derechos de autor de 'KÍSEM' y de sus filiales. El 'Asociado'  no podrá utilizar el nombre comercial de 'KISEM' o marcas registradas, bajo los cuales se presentan comercialmente los productos, en ningún medio de publicidad, tarjetas de presentación, carteles, folletos vehículos, chequeras o papelería, sin el previo consentimiento por escrito de Kísem.\n\n"
        //+ "DÉCIMA TERCERA: El 'Asociado' no podrá en ningún momento erigirse como representante, agente, sucursal, empleado, funcionario, vendedor o apoderado de 'KISEM'.\n\n"
        //+ "DÉCIMA CUARTA: El 'Asociado' se compromete a actuar con honestidad ante sus prospectos y demás compañeros Asociados, realizando sus actividades siempre en equipo y armonía, de acuerdo con las políticas y ética de 'KISEM'.\n\n"
        //+ "DÉCIMA QUINTA: Si durante el ejercicio de sus actividades de distribución y comercialización, el Asociado encuentra personas o clientes interesados en la distribución de Productos KISEM, éste podrá invitarlos a que soliciten a KISEM su incorporación como Asociados. En caso de ser aceptados, éstos últimos pasarán a formar parte de su organización o red de distribución independiente bajo su auspicio o patrocinio, sumándose el volumen de sus compras al volumen de compras del Asociado, conforme a lo establecido en el Plan de Negocio.\n\n"
        //+ "DÉCIMA SEXTA: El precio de compra del Asociado será regulado por la lista de precios vigente publicada por KISEM a la fecha de efectuar cada compra, aplicable a Productos y materiales de promoción. KISEM se reserva el derecho de modificar su lista de precios en cualquier momento, entrando en vigor en la fecha que se publique dicho cambio\n\n"
        //+ "DÉCIMA SÉPTIMA: KISEM se reserva el derecho de modificar en cualquier momento su Plan de Negocio, hecho que el Distribuidor Independiente acepta y reconoce. En caso que éste último no esté de acuerdo con alguna modificación, tendrá derecho a notificar y solicitar por escrito a KISEM la terminación de este Contrato\n\n"
        //+ "DÉCIMA OCTAVA: La duración de este contrato será indefinida, y podrá darse por terminado a petición de cualquiera de las partes en cualquier momento y sin causa alguna, mediante aviso por escrito proporcionado con 30 días naturales de anticipación, sin responsabilidad alguna para la parte que haya solicitado la terminación, excepto la liquidación de las operaciones pendientes entre ambas partes. En caso que el Asociado dé por terminado este contrato, deberá esperar al menos 6 meses para volver a presentar una nueva solicitud de contrato. La terminación de este contrato podrá hacerse efectiva sin presentar aviso por escrito en caso de que exista algún impedimento o causa de fuerza mayor  que obligue o impida a la empresa continuar con sus actividades comerciales. \n\n"
        //+ "En caso de incumplimiento del Distribuidor Independiente del Plan de Negocio o de cualquiera de sus obligaciones derivadas del presente contrato, KISEM podrá dar por terminado de manera inmediata este contrato mediante aviso por escrito y sin necesidad de declaración judicial.\n\n"
        //+ "Si(el) 'Asociado' no realizara ninguna operación de compra en un periodo consecutivo de 4 meses, automáticamente se le dará de baja de 'KISEM', pudiendo nuevamente ser inscrito como socio al ser patrocinado por segunda ocasión por su mismo patrocinador o por otro Socio Consumidor, en una nueva posición y nuevo ID, sin embargo perdería la totalidad de sus derechos sobre las regalías y/o bonos que genere su red descendente.\n\n"
        //+ "DÉCIMA NOVENA: El 'Asociado' acepta de KISEM que se le retengan los impuestos correspondientes al ISR, IVA, etc., derivados de las comisión y/bonificaciones o pagos y demás actos comerciales  y de promoción gravables que realice de acuerdo con las disposiciones fiscales vigentes salvo decisión en contrario (por escrito) emitida por el 'Asociado'.\n"
        //+ "De acuerdo con lo anterior, comunico mi opción (firmando tal decisión en la última hoja de este contrato) por el régimen fiscal de mis ingresos que recibiré de la empresa Kísem de México, S. de R.L. de C.V., los cuales tendrán el tratamiento de 'Actividades Empresariales que se asimilan opcionalmente a salarios' de acuerdo al artículo 110, fracción VI de la Ley de Impuestos sobre la Renta en vigor, Acepto la retención del Impuesto Sobre la Renta que me corresponda de acuerdo a la tabla del Art. 113 de la Ley del ISR en vigor.\n"
        //+ "En caso de que el 'Asociado' desee que no le hagan dicha retención, deberá de entregarle a Kísem recibo de honorarios o factura por el valor del pago entregado.\n"
        //+ "Kísem enterará al Servicio de Administración Tributaria, dichos impuestos retenidos entregándole al 'Asociado' el comprobante de retención respectivo cuando él así lo solicite.\n"
        //+ "VIGÉSIMA: El 'Asociado' da su consentimiento pleno para que las regalías y/o bonos o premios en efectivo derivadas de su promoción objeto de este contrato, le sean depositados en una cuanta bancaria específica (de acuerdo a las indicaciones de KISEM). Dándose por parte del 'Distribuidor' la aceptación de este instrumento de pago como válido, siendo el comprobante de depósito y/o estado de cuenta que el banco le otorgue a 'KISEM', un instrumento válido para todos los efectos legales que correspondan. A dicho depósito se le retendrán los impuestos correspondientes mencionados en el párrafo anterior.\n\n"
        //+ "VIGÉSIMA PRIMERA: LEYES Y JURISDICCIÓN: Las partes se regirán por lo dispuesto en éste contrato mercantil y en lo establecido por el Código Civil para el estado de Querétaro. Para todo lo relativo con la interpretación y cumplimiento del presente contrato, las partes se someten expresamente a la jurisdicción de los tribunales de la Ciudad de Querétaro, Querétaro, México, renunciando expresamente a cualquier fuero de domicilio actual o futuro que pudiese corresponderle. De igual manera para todo lo no previsto en este contrato, las partes se sujetan al Plan de Negocio, o en su defecto al Código de Comercio vigente en el estado de Querétaro.\n\n"
        //+ "VIGÉSIMA SEGUNDA: Todo aviso o notificación relacionada con este contrato se hará por escrito y será enviado por correo certificado y con porte pagado a los domicilios especificados al inicio del presente contrato, salvo que exista notificación por escrito de cambio de domicilio de cualquiera de las partes.\n\n"
        //+ "VIGÉSIMA TERCERA: Si alguna de las cláusulas de de este contrato fuera declarada nula, o sin efecto legal mediante sentencia judicial o resolución de autoridad competente, las demás cláusulas no dejarán de tener pleno valor y vigencia.\n\n"
        //+ "VIGÉSIMA CUARTA: Bajo protesta de decir verdad, ambas partes manifiestan que el presente contrato y Plan de Negocio carece de vicios como son error, dolo u omisión. ";
    }

}