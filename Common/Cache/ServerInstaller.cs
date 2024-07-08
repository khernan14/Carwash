using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Metodos {
    public class ServerInstaller {

        public static string UserLaptopName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        private static string extension = ".txt";
        public static string Instancia = "SQLEXPRESS";
        public static string Usuario = "CarwashAdmin";
        public static string Password = "SystemC@rwash2024";
        public static string DataBaseName { get; set; } = "dbCarwash"; // Default value can be overridden
        public static string Script => DataBaseName + extension;

        public static string servidor = $".\\{Instancia}";

		public static string Configuration => $@"; Microsoft SQL Server Configuration file for SQL Server 2022 Express
			[OPTIONS]

			; Specifies a Setup work flow, like INSTALL, UNINSTALL, or UPGRADE.
			; This is a required parameter.
			ACTION=""Install""

			; Use the /IAcceptSQLServerLicenseTerms parameter to accept the SQL Server license terms.
			IAcceptSQLServerLicenseTerms=""True""

			; Specifies that SQL Server Setup should not display the privacy statement when run silently.
			SUPPRESSPRIVACYSTATEMENTNOTICE=""True""

			; Specify the installation directory.
			INSTALLSHAREDDIR=""C:\Program Files\Microsoft SQL Server""
			INSTALLSHAREDWOWDIR=""C:\Program Files (x86)\Microsoft SQL Server""

			; Specify the installation directory for the instance.
			INSTANCEDIR=""C:\Program Files\Microsoft SQL Server""

			; Specify a default or named instance.
			INSTANCEID=""{Instancia}""
			INSTANCENAME=""{Instancia}""

			; The following are optional settings that you can customize:
			; Specify SQL Server administrators.
			SQLSYSADMINACCOUNTS=""BUILTIN\Administrators""

			; Specify the location for the SQL Server data files.
			SQLUSERDBDIR=""C:\SQLData""
			SQLUSERDBLOGDIR=""C:\SQLLogs""
			SQLTEMPDBDIR=""C:\SQLTemp""
			SQLTEMPDBLOGDIR=""C:\SQLTemp""

			; Specify the service accounts.
			AGTSVCACCOUNT=""NT AUTHORITY\NETWORK SERVICE""
			AGTSVCPASSWORD=""*""
			SQLSVCACCOUNT=""NT Service\MSSQL${Usuario}""
			SQLSVCPASSWORD=""{Password}""
			SQLSVCSTARTUPTYPE=""Automatic""

			; Specify the SQL Server system administrators.
			ADDCURRENTUSERASSQLADMIN=""False""

			; Specify authentication mode. (Windows or Mixed mode)
			SECURITYMODE=""SQL""
			SAPWD=""{Password}""

			; Specify the collation.
			SQLCOLLATION=""SQL_Latin1_General_CP1_CI_AS""

			; Specify the location for SQL Server setup logs.
			INSTALLSQLDATADIR=""C:\SQLData""

			; Specify the TCP/IP port for the Database Engine.
			TCPENABLED=""1""
			TCPPORT=""1433""

			; Enable or disable the Browser service.
			BROWSERSVCSTARTUPTYPE=""Disabled""

			; Feature selection: SQLEngine, FullText, Replication, etc.
			FEATURES=SQLEngine, Replication

			; Quiet installation (no UI)
			QUIET=""True""

			; Display setup progress (set to True if QUIET is False)
			QUIETSIMPLE=""True""

			; Enable installation progress logging
			INDICATEPROGRESS=""True""

			; Use Microsoft Update to receive updates for SQL Server
			USEMICROSOFTUPDATE=""False""
			";

        public static string DeleteDataBase => $@"
			ALTER DATABASE [{DataBaseName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
			DROP DATABASE [{DataBaseName}]";

		public static string CreateUsuario => $@"
USE [{DataBaseName}]
GO
CREATE PROCEDURE [dbo].[CRUD_USUARIOS]
@nombres nvarchar(60) = null,
@usuario nvarchar(50) = null,
@password nvarchar(50) = null,
@icono image = null,
@nombreIcono nvarchar(max) = null,
@correo nvarchar(300) = null,
@rol nvarchar(max) = null,
@codigo int = null,
@buscar nvarchar(max) = null,
@accion nvarchar(50) = null
AS
BEGIN
	IF(@accion = 'Mostrar')
	BEGIN
		SELECT usuarioID, nombres AS [Nombre Completo], usuario AS Usuario, password AS Contraseña, icono, nombreIcono, correo AS Correo, rol
		FROM usuarios
		WHERE estado = 'Activo'
	END

	IF(@accion = 'Insertar')
	BEGIN
		IF EXISTS(SELECT usuario FROM usuarios WHERE (usuario = @usuario AND estado = 'Activo'))
			RAISERROR('El usuario ya existe, Por favor intente de nuevo', 16, 1);
		ELSE
			INSERT INTO usuarios
				VALUES (
					@nombres, @usuario, @password, @icono, @nombreIcono, @correo, @rol, 'Activo'
				)
	END

	IF(@accion = 'Actualizar')
	BEGIN
		IF EXISTS(SELECT usuario, usuarioID FROM usuarios WHERE (usuario = @usuario AND usuarioID <> @codigo AND estado = 'Activo') OR (nombres	= @nombres AND usuarioID <> @codigo AND estado = 'Activo'))
			RAISERROR('El usuario ya existe, Por favor intente de nuevo', 16, 1);
		ELSE
			UPDATE usuarios SET
				 nombres = @nombres
				,usuario = @usuario
				,password = @password
				,icono = @icono
				,nombreIcono = @nombreIcono
				,correo = @correo
				,rol = @rol
			WHERE usuarioID = @codigo
	END

	IF(@accion = 'Eliminar')
	BEGIN
		IF EXISTS(SELECT usuario FROM usuarios WHERE usuario = 'Administrador')
			RAISERROR('El usuario Administrador no se puede eliminar, si se borra le quitas el acceso al sistema', 16, 1)
		ELSE
			UPDATE usuarios
			SET estado = 'Eliminado'
			WHERE usuarioID = @codigo AND usuario <> 'Administrador'
	END

	IF(@accion = 'Buscar')
	BEGIN
		SELECT usuarioID, nombres AS [Nombre Completo], usuario AS Usuario, password AS Contraseña, icono, nombreIcono, correo AS Correo, rol
		FROM usuarios
		WHERE nombres + usuario + correo LIKE '%' + @buscar + '%' AND estado = 'Activo'
	END
END";

        public static string CreateDataBase => $@"
USE [master]
GO
ALTER DATABASE [dbCarwash] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbCarwash].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbCarwash] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbCarwash] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbCarwash] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbCarwash] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbCarwash] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbCarwash] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbCarwash] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbCarwash] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbCarwash] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbCarwash] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbCarwash] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbCarwash] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbCarwash] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbCarwash] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbCarwash] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dbCarwash] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbCarwash] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbCarwash] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbCarwash] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbCarwash] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbCarwash] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbCarwash] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbCarwash] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [dbCarwash] SET  MULTI_USER 
GO
ALTER DATABASE [dbCarwash] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbCarwash] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbCarwash] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbCarwash] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dbCarwash] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [dbCarwash] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [dbCarwash] SET QUERY_STORE = ON
GO
ALTER DATABASE [dbCarwash] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [dbCarwash]
GO
/****** Object:  Table [dbo].[cajas]    Script Date: 8/6/2024 22:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cajas](
	[cajaID] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [nvarchar](50) NULL,
	[serialPC] [nvarchar](50) NULL,
	[impresoraTicket] [nvarchar](max) NULL,
	[impresoraA4] [nvarchar](max) NULL,
	[estado] [nvarchar](50) NULL,
	[tipoCaja] [nvarchar](50) NULL,
 CONSTRAINT [PK_cajas] PRIMARY KEY CLUSTERED 
(
	[cajaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[categorias]    Script Date: 8/6/2024 22:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categorias](
	[categoriaID] [int] IDENTITY(1,1) NOT NULL,
	[linea] [nvarchar](50) NULL,
	[forDefault] [nvarchar](50) NULL,
 CONSTRAINT [PK_categorias] PRIMARY KEY CLUSTERED 
(
	[categoriaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[consumidores]    Script Date: 8/6/2024 22:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[consumidores](
	[consumidorID] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](max) NULL,
	[direccionFacturacion] [nvarchar](max) NULL,
	[ruc] [nvarchar](max) NULL,
	[telefono] [nvarchar](50) NULL,
	[tipoConsumidor] [nvarchar](50) NULL,
	[estado] [nvarchar](50) NULL,
	[saldo] [numeric](18, 2) NULL,
 CONSTRAINT [PK_consumidores] PRIMARY KEY CLUSTERED 
(
	[consumidorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[empresas]    Script Date: 8/6/2024 22:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[empresas](
	[empresaID] [int] IDENTITY(1000,1) NOT NULL,
	[nombre] [nvarchar](50) NULL,
	[logo] [image] NULL,
	[impuesto] [nvarchar](50) NULL,
	[porcentajeImpuesto] [numeric](18, 0) NULL,
	[moneda] [nvarchar](50) NULL,
	[usaImpuesto] [nvarchar](50) NULL,
	[modoBusqueda] [nvarchar](50) NULL,
	[carpetaBackups] [nvarchar](max) NULL,
	[correo] [nvarchar](max) NULL,
	[ultimaFechaBackup] [nvarchar](50) NULL,
	[ultimaFechaBackupDate] [datetime] NULL,
	[frecuenciaBackups] [int] NULL,
	[estado] [nvarchar](50) NULL,
	[tipoEmpresa] [nvarchar](50) NULL,
	[pais] [nvarchar](max) NULL,
	[redondeo] [nvarchar](50) NULL,
 CONSTRAINT [PK_empresas] PRIMARY KEY CLUSTERED 
(
	[empresaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[kardex]    Script Date: 8/6/2024 22:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[kardex](
	[kardexID] [int] IDENTITY(1000,1) NOT NULL,
	[fecha] [datetime] NULL,
	[motivo] [nvarchar](200) NULL,
	[cantidad] [numeric](18, 2) NULL,
	[productoID] [int] NULL,
	[usuarioID] [int] NULL,
	[tipo] [nvarchar](50) NULL,
	[estado] [nvarchar](50) NULL,
	[total]  AS ([cantidad]*[costoUnitario]),
	[costoUnitario] [numeric](18, 2) NULL,
	[cantidadAnterior] [numeric](18, 2) NULL,
	[cantidadActual] [numeric](18, 2) NULL,
	[cajaID] [int] NULL,
 CONSTRAINT [PK_kardex] PRIMARY KEY CLUSTERED 
(
	[kardexID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[licencias]    Script Date: 8/6/2024 22:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[licencias](
	[licenciaID] [int] IDENTITY(1,1) NOT NULL,
	[S] [nvarchar](max) NULL,
	[F] [nvarchar](max) NULL,
	[E] [nvarchar](max) NULL,
	[FA] [nvarchar](max) NULL,
 CONSTRAINT [PK_licencias] PRIMARY KEY CLUSTERED 
(
	[licenciaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[logins]    Script Date: 8/6/2024 22:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[logins](
	[loginID] [int] IDENTITY(1,1) NOT NULL,
	[serialPCID] [nvarchar](max) NULL,
	[usuarioID] [int] NULL,
 CONSTRAINT [PK_logins] PRIMARY KEY CLUSTERED 
(
	[loginID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[movimientosCierresCajas]    Script Date: 8/6/2024 22:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[movimientosCierresCajas](
	[cierreCajaID] [int] IDENTITY(1,1) NOT NULL,
	[fechaInicio] [datetime] NULL,
	[fechaFin] [datetime] NULL,
	[fechaCierre] [datetime] NULL,
	[ingresos] [numeric](18, 2) NULL,
	[egresos] [numeric](18, 2) NULL,
	[saldoRestante] [numeric](18, 2) NULL,
	[usuarioID] [int] NULL,
	[totalCalculado] [numeric](18, 2) NULL,
	[totalReal] [numeric](18, 2) NULL,
	[estado] [nvarchar](50) NULL,
	[diferencia] [numeric](18, 2) NULL,
	[cajaID] [int] NULL,
 CONSTRAINT [PK_movimientosCierresCajas] PRIMARY KEY CLUSTERED 
(
	[cierreCajaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[productos]    Script Date: 8/6/2024 22:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[productos](
	[productoID] [int] IDENTITY(1000,1) NOT NULL,
	[descripcion] [nvarchar](50) NULL,
	[categoriaID] [int] NULL,
	[usaInventario] [nvarchar](50) NULL,
	[stock] [nvarchar](50) NULL,
	[precioCompra] [numeric](18, 2) NULL,
	[fechaVencimiento] [nvarchar](50) NULL,
	[precioVenta] [numeric](18, 2) NULL,
	[barcode] [nvarchar](50) NULL,
	[tipoVenta] [nvarchar](50) NULL,
	[impuesto] [nvarchar](50) NULL,
	[stockMinimo] [numeric](18, 2) NULL,
	[precioMayoreo] [numeric](18, 2) NULL,
	[subTotalPV]  AS ([precioVenta]-([precioVenta]*[impuesto])/(100)),
	[subTotalPM]  AS ([precioMayoreo]-([precioMayoreo]*[impuesto])/(100)),
	[aPartirDe] [numeric](18, 2) NULL,
 CONSTRAINT [PK_productos] PRIMARY KEY CLUSTERED 
(
	[productoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[serializacion]    Script Date: 8/6/2024 22:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[serializacion](
	[serializacionID] [int] IDENTITY(1,1) NOT NULL,
	[serie] [nvarchar](50) NULL,
	[cantidadNumeros] [nvarchar](50) NULL,
	[numeroFin] [nvarchar](50) NULL,
	[destino] [nvarchar](50) NULL,
	[tipoDocumento] [nvarchar](50) NULL,
	[forDefault] [nvarchar](50) NULL,
 CONSTRAINT [PK_serializacion] PRIMARY KEY CLUSTERED 
(
	[serializacionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tickets]    Script Date: 8/6/2024 22:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tickets](
	[ticketID] [int] IDENTITY(1,1) NOT NULL,
	[empresaID] [int] NULL,
	[identificadorFiscal] [nvarchar](max) NULL,
	[direccion] [nvarchar](max) NULL,
	[provincia] [nvarchar](max) NULL,
	[nombreMoneda] [nvarchar](max) NULL,
	[agradecimiento] [nvarchar](max) NULL,
	[paginaWeb] [nvarchar](max) NULL,
	[anuncio] [nvarchar](max) NULL,
	[datosFiscalesAuth] [nvarchar](max) NULL,
	[forDefault] [nvarchar](max) NULL,
 CONSTRAINT [PK_tickets] PRIMARY KEY CLUSTERED 
(
	[ticketID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuarios]    Script Date: 8/6/2024 22:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuarios](
	[usuarioID] [int] IDENTITY(1,1) NOT NULL,
	[nombres] [nvarchar](60) NULL,
	[usuario] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL,
	[icono] [image] NULL,
	[nombreIcono] [nvarchar](max) NULL,
	[correo] [nvarchar](300) NULL,
	[rol] [nvarchar](max) NULL,
	[estado] [nvarchar](50) NULL,
 CONSTRAINT [PK_usuarios] PRIMARY KEY CLUSTERED 
(
	[usuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[CRUD_CAJAS]    Script Date: 8/6/2024 22:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CRUD_CAJAS]
@descripcion NVARCHAR(50) = NULL,
@serialPC NVARCHAR(50) = NULL,
@impresoraTicket NVARCHAR(MAX) = NULL,
@impresoraA4 NVARCHAR(MAX) = NULL,
@tipoCaja NVARCHAR(50) = NULL,
@accion NVARCHAR(50) = NULL,

@serie NVARCHAR(50) = NULL,
@cantidadNumeros NVARCHAR(50) = NULL,
@numeroFin NVARCHAR(50) = NULL,
@destino NVARCHAR(50) = NULL,
@tipoDocumento NVARCHAR(50) = NULL,
@forDefault NVARCHAR(50) = NULL
AS	
BEGIN
	IF(@accion = 'Insertar')
	BEGIN
		IF EXISTS(SELECT descripcion, serialPC FROM cajas WHERE descripcion = @descripcion AND serialPC = @serialPC)
		BEGIN
			RAISERROR('Ya existe una caja con ese nombre o ya existe una caja para este PC', 16, 1)
		END
		ELSE
		BEGIN
			DECLARE @estado AS NVARCHAR(50)
			SET @estado = 'Recien Creada'

			INSERT INTO cajas
			VALUES (
				@descripcion,
				@serialPC,
				@impresoraTicket,
				@impresoraA4,
				@estado,
				@tipoCaja
			)
		END
	END

	IF(@accion = 'InsertarSerializacion')
	BEGIN
		IF EXISTS(SELECT tipoDocumento FROM serializacion WHERE tipoDocumento = @tipoDocumento)
		BEGIN
			RAISERROR('Este comprobante ya existe, ingrese uno nuevo', 16, 1);
		END
		ELSE
		BEGIN
			INSERT INTO serializacion
			VALUES (
				@serie,
				@cantidadNumeros,
				@numeroFin,
				@destino,
				@tipoDocumento,
				@forDefault
			)
		END
	END
END
GO
/****** Object:  StoredProcedure [dbo].[CRUD_CATEGORIAS]    Script Date: 8/6/2024 22:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CRUD_CATEGORIAS]
@categoriaID INT = NULL,
@linea NVARCHAR(50) = NULL,
@default NVARCHAR(50) = NULL,
@accion NVARCHAR(50) = NULL,
@buscar NVARCHAR(50) = NULL
AS
BEGIN
	IF(@accion = 'Mostrar')
	BEGIN
		SELECT categoriaID AS ID, linea AS Grupo
		FROM categorias
	END
	IF(@accion = 'Buscar')
	BEGIN
		SELECT categoriaID AS ID, linea AS Grupo
		FROM categorias
		WHERE linea like '%' + @buscar + '%'
	END
	IF(@accion = 'Insertar')
	BEGIN
		IF EXISTS(SELECT linea FROM categorias WHERE linea = @linea)
		BEGIN
			RAISERROR('Ya existe un grupo con este nombre, ingrese de nuevo', 16, 1)
		END
		ELSE
		BEGIN
			INSERT INTO categorias(
			linea,
			forDefault
			) VALUES (
				@linea,
				@default
			)
		END
	END

	IF(@accion = 'Actualizar')
	BEGIN
		IF EXISTS(SELECT linea FROM categorias WHERE linea = @linea AND categoriaID = @categoriaID)
		BEGIN
			RAISERROR('Ya existe un grupo con ese nombre', 16, 1);
		END
		ELSE
		BEGIN
			UPDATE categorias
			SET linea = @linea
			WHERE categoriaID = @categoriaID
		END
	END
END
GO
/****** Object:  StoredProcedure [dbo].[CRUD_CONSUMIDORES]    Script Date: 8/6/2024 22:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[CRUD_CONSUMIDORES]
@accion NVARCHAR(50) = NULL,
@nombre NVARCHAR(MAX) = NULL,
@direccionFacturacion NVARCHAR(MAX) = NULL,
@ruc NVARCHAR(MAX) = NULL,
@telefono NVARCHAR(50) = NULL,
@tipoConsumidor NVARCHAR(50) = NULL, /*Puede ser cliente o proveedor*/
@estado NVARCHAR(50) = NULL,
@saldo NUMERIC(18, 2) = NULL
AS
BEGIN
	IF(@accion = 'Insertar')
	BEGIN
		IF EXISTS(SELECT nombre FROM consumidores WHERE nombre = @nombre)
		BEGIN
			RAISERROR('Ya existe un registro con ese nombre', 16, 1);
		END
		ELSE
		BEGIN
			INSERT INTO consumidores
			VALUES (
				@nombre,
				@direccionFacturacion,
				@ruc,
				@telefono,
				@tipoConsumidor,
				@estado,
				@saldo
			)
		END
	END
END
GO
/****** Object:  StoredProcedure [dbo].[CRUD_EMPRESA]    Script Date: 8/6/2024 22:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[CRUD_EMPRESA]
@nombre NVARCHAR(50) = NULL,
@logo IMAGE = NULL,
@impuesto NVARCHAR(50) = NULL,
@porcentajeImpuesto NUMERIC(18,2) = NULL,
@moneda NVARCHAR(50) = NULL,

@usaImpuesto NVARCHAR(50) = NULL,
@modoBusqueda NVARCHAR(50) = NULL,
@carpetaBackups NVARCHAR(MAX) = NULL,
@correo NVARCHAR(MAX) = NULL,
@ultimaFechaBackup NVARCHAR(50) = NULL,

@ultimaFechaBDate DATE = NULL,
@frecuenciaBackups INT = NULL,
@estado NVARCHAR(50) = NULL,
@tipoEmpresa NVARCHAR(50) = NULL,
@pais NVARCHAR(MAX) = NULL,
@redondeo NVARCHAR(50) = NULL,
@accion NVARCHAR(50) = NULL
AS
BEGIN
	IF(@accion = 'Insertar')
	BEGIN
		IF EXISTS(SELECT nombre FROM empresas WHERE nombre = @nombre)
		BEGIN
			RAISERROR('Ya existe una empresa con ese nombre, ingrese uno diferente', 16, 1);
		END
		ELSE
		BEGIN
			INSERT INTO empresas
			VALUES (
				@nombre,
				@logo,
				@impuesto,
				@porcentajeImpuesto,
				@moneda,
				@usaImpuesto,
				@modoBusqueda,
				@carpetaBackups,
				@correo,
				@ultimaFechaBackup,
				@ultimaFechaBDate,
				@frecuenciaBackups,
				@estado,
				@tipoEmpresa,
				@pais,
				@redondeo
			)
		END
	END
END
GO
/****** Object:  StoredProcedure [dbo].[CRUD_KARDEX]    Script Date: 8/6/2024 22:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[CRUD_KARDEX]
@productoID INT = NULL,
@accion NVARCHAR(50) = NULL,

@fecha DATE = NULL,
@tipo NVARCHAR(50) = NULL,
@usuarioID INT = NULL,

@buscar NVARCHAR(50) = NULL
AS
BEGIN
	IF(@accion = 'BuscarMovimientos')
	BEGIN
		SELECT A.fecha, B.descripcion, A.motivo AS Movimiento, A.cantidadAnterior, A.tipo, A.cantidad, A.cantidadActual, C.nombres AS Cajero, D.linea AS categoria, E.nombre, E.logo
		FROM kardex A INNER JOIN productos b
			ON
			A.productoID = B.productoID INNER JOIN usuarios C
			ON
				A.usuarioID = C.usuarioID CROSS JOIN empresas E INNER JOIN categorias D
			ON
				D.categoriaID = B.categoriaID
		WHERE B.productoID = @productoID ORDER BY A.fecha DESC
	END

	IF(@accion = 'FiltrarKardex')
	BEGIN
		SELECT A.fecha, B.descripcion, A.motivo AS Movimiento, A.cantidadAnterior, A.tipo, A.cantidad, A.cantidadActual, C.nombres AS Cajero, D.linea AS categoria,
					E.nombre, E.logo
		FROM kardex A INNER JOIN productos b
			ON
			A.productoID = B.productoID INNER JOIN usuarios C
			ON
				A.usuarioID = C.usuarioID CROSS JOIN empresas E INNER JOIN categorias D
			ON
				D.categoriaID = B.categoriaID
		WHERE A.usuarioID = @usuarioID AND (A.tipo = @tipo OR @tipo = '--Todos--') AND CONVERT(DATE, A.fecha) = CONVERT(DATE, @fecha)
	END

	IF(@accion = 'FiltrarKardexAcumulados')
	BEGIN
		SELECT B.descripcion, A.tipo, SUM(A.cantidad)[Cantidad Total], C.nombres AS Cajero
		FROM kardex A INNER JOIN productos B
			ON
			A.productoID = B.productoID INNER JOIN usuarios C
			ON
				A.usuarioID = C.usuarioID
		WHERE A.usuarioID = @usuarioID AND (A.tipo = @tipo OR @tipo = '--Todos--') AND CONVERT(DATE, A.fecha) = CONVERT(DATE, @fecha)
		GROUP BY B.descripcion, A.tipo, C.nombres
		ORDER BY SUM(A.cantidad)
	END

	IF(@accion = 'StockMinimo')
	BEGIN
		SELECT A.barcode, A.descripcion, A.precioCompra, B.linea AS Categoria, A.stock, A.stockMinimo, E.nombre, E.logo
		FROM productos A 
			CROSS JOIN empresas E 
			INNER JOIN categorias B ON A.categoriaID = B.categoriaID
		WHERE usaInventario = 'SI' 
			AND TRY_CONVERT(float, stock) <= TRY_CONVERT(float, stockMinimo)
	END

	IF(@accion = 'MostrarInventarios')
	BEGIN
		SELECT A.barcode, A.descripcion, A.precioCompra AS Costo, A.precioVenta, A.stock, A.stockMinimo, b.linea AS Categoria, 
				A.precioCompra * TRY_CONVERT(float, A.stock)Importe, E.nombre, E.logo
		FROM productos A CROSS JOIN empresas E INNER JOIN categorias B
			ON
				A.categoriaID = B.categoriaID
		WHERE (descripcion + barcode) LIKE '%' + @buscar + '%' AND usaInventario = 'SI'
	END

	IF(@accion = 'Cantidades')
	BEGIN
		SELECT COUNT(productoID)totalProductos, CONCAT_WS('. ', moneda, CONVERT(NUMERIC(18,2),sum(precioCompra * stock )))Costo
		FROM productos CROSS JOIN empresas
		WHERE usaInventario = 'SI'
		GROUP BY moneda
	END

	IF(@accion = 'ProductosVencidos')
	BEGIN
		SELECT productoID, barcode, descripcion, fechaVencimiento, stock, nombre, logo,
		CASE WHEN fechaVencimiento = 'No Aplica' THEN NULL
			ELSE DATEDIFF(DAY, CONVERT(DATE, fechaVencimiento), CONVERT(DATE, GETDATE())) END AS [Dias Vencidos]
		FROM productos CROSS JOIN empresas
		WHERE (barcode + descripcion) LIKE '%' + @buscar + '%' AND (fechaVencimiento <> 'No Aplica' OR fechaVencimiento IS NULL) 
				AND TRY_CONVERT(DATE, fechaVencimiento) <= CONVERT(DATE, GETDATE())
		ORDER BY [Dias Vencidos] ASC
	END

	IF(@accion = 'ProductosVencidosMenor30')
	BEGIN
		SELECT productoID, barcode, descripcion, fechaVencimiento, stock, nombre, logo,
				CASE WHEN fechaVencimiento = 'No Aplica' THEN NULL
					ELSE DATEDIFF(DAY, CONVERT(DATE, fechaVencimiento), CONVERT(DATE, GETDATE()))*(-1) END AS [Dias a Vencer]
		FROM productos CROSS JOIN empresas
		WHERE (fechaVencimiento <> 'No Aplica' OR fechaVencimiento IS NULL) 
				AND TRY_CONVERT(DATE, fechaVencimiento) > CONVERT(DATE, GETDATE()) AND DATEDIFF(DAY, CONVERT(DATE, fechaVencimiento), CONVERT(DATE, GETDATE()))*(-1) <= 30
		ORDER BY [Dias a Vencer] ASC
	END

	IF(@accion = 'rpInventario')
	BEGIN
		SELECT A.barcode, A.descripcion, A.precioCompra AS Costo, A.precioVenta, A.stock, A.stockMinimo, b.linea AS Categoria, 
				A.precioCompra * TRY_CONVERT(float, A.stock)Importe, E.nombre, E.logo
		FROM productos A CROSS JOIN empresas E INNER JOIN categorias B
			ON
				A.categoriaID = B.categoriaID
		WHERE stock <> 'Ilimitado'
	END
END
GO
/****** Object:  StoredProcedure [dbo].[CRUD_PRODUCTOS]    Script Date: 8/6/2024 22:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CRUD_PRODUCTOS]
@productID INT = NULL,
@descripcion NVARCHAR(50) = NULL,
@buscar NVARCHAR(100) = NULL,
@categoriaID INT = NULL,
@usaInventario NVARCHAR(50) = NULL,
@stock NVARCHAR(50) = NULL,
@precioCompra NUMERIC(18, 2) = NULL,
@fechaVencimiento NVARCHAR(50) = NULL,
@precioVenta NUMERIC(18, 2) = NULL,
@barcode NVARCHAR(50) = NULL,
@tipoVenta NVARCHAR(50) = NULL,
@impuesto NVARCHAR(50) = NULL,
@stockMinimo NVARCHAR(50) = NULL,
@precioMayoreo NUMERIC(18, 2) = NULL,
@aPartirDe NUMERIC(18, 2) = NULL,
@accion NVARCHAR(50) = NULL,

@fecha DATETIME = NULL,
@motivo NVARCHAR(200) = NULL,
@cantidad NUMERIC(18,2) = NULL,
@usuarioID INT = NULL,
@tipo NVARCHAR(50) = NULL,
@estado NVARCHAR(50) = NULL,
@cajaID INT = NULL
AS
BEGIN
	IF(@accion = 'Mostrar')
	BEGIN
		SELECT TOP 10 A.productoID AS ID, B.categoriaID, A.barcode AS Codigo, B.linea AS Grupo, A.descripcion AS Descripcion, A.impuesto AS Impuesto,
			A.precioCompra AS [Precio Compra], A.precioMayoreo AS [Precio Mayoreo], A.stockMinimo AS [Stock Minimo], 
			A.fechaVencimiento AS [Fecha Vencimiento], A.stock AS Stock, A.precioVenta AS [Precio Venta], A.usaInventario, a.tipoVenta, A.aPartirDe
		FROM productos A INNER JOIN categorias B
		ON
			A.categoriaID = B.categoriaID
		WHERE descripcion LIKE '%' + @buscar + '%' OR linea LIKE '%' + @buscar + '%' OR barcode LIKE '%' + @buscar + '%' OR productoID LIKE '%' + @buscar + '%'
	END

	IF(@accion = 'Autocomplete')
	BEGIN
		SELECT TOP 10 productoID, descripcion FROM productos WHERE descripcion LIKE '%' + @descripcion + '%'
	END

	IF(@accion = 'AutocompleteKardex')
	BEGIN
		SELECT A.productoID, (descripcion) AS Descripcion, B.linea, A.usaInventario, A.stock, A.precioCompra, A.fechaVencimiento,
			A.precioVenta, A.barcode, A.tipoVenta, A.impuesto, A.stockMinimo, A.precioMayoreo, A.subTotalPV, A.subTotalPM
		FROM productos A INNER JOIN categorias B
			ON
			A.categoriaID = B.categoriaID
		WHERE (A.descripcion + B.linea + A.barcode) LIKE '%' + @buscar + '%' AND A.usaInventario = 'SI'
	END

	IF(@accion = 'InsertarProductos')
	BEGIN
		IF EXISTS(SELECT descripcion, barcode FROM productos WHERE descripcion = @descripcion OR barcode = @barcode)
		BEGIN
			RAISERROR('Ya existe un producto con este nombre/codigo', 16, 1)
			RAISERROR('Por favor ingrese un nuevo', 16, 1)
		END
		ELSE
		BEGIN
			DECLARE @productoID INT
			INSERT INTO [dbo].[productos]
				([descripcion]
				,[categoriaID]
				,[usaInventario]
				,[stock]
				,[precioCompra]
				,[fechaVencimiento]
				,[precioVenta]
				,[barcode]
				,[tipoVenta]
				,[impuesto]
				,[stockMinimo]
				,[precioMayoreo]
				,[aPartirDe])
			VALUES
				(@descripcion
				,@categoriaID
				,@usaInventario
				,@stock
				,@precioCompra
				,@fechaVencimiento
				,@precioVenta
				,@barcode
				,@tipoVenta
				,@impuesto
				,@stockMinimo
				,@precioMayoreo
				,@aPartirDe)
			SELECT @productoID = SCOPE_IDENTITY();

			DECLARE @cantidadActual AS NUMERIC(18,2)
			DECLARE @cantidadAnterior AS NUMERIC(18,2)
			DECLARE @costoUnitario NUMERIC(18,2)
		
			SET @cantidadActual = (SELECT stock  FROM productos WHERE productoID = @productoID and usaInventario = 'SI' )
			SET @costoUnitario = (SELECT precioCompra FROM productos WHERE productoID = @productoID and usaInventario = 'SI' )		   
			SET @cantidadAnterior = @cantidadActual + @cantidadAnterior
			SET @usaInventario = (SELECT usaInventario FROM productos WHERE productoID = @productoID and usaInventario ='SI' )

			IF(@usaInventario = 'SI')
			BEGIN
				INSERT INTO [dbo].[kardex]
				VALUES (
					@fecha,
					@motivo,
					@cantidad,
					@productoID,
					@usuarioID,
					@tipo,
					@estado, 
					@costoUnitario,
					@cantidadAnterior,
					@cantidadActual,
					@cajaID
				)
			END
		END
	END
	/*Actualizar Kardex -- Aun sin terminar*/
	IF(@accion = 'ActualizarProductos')
	BEGIN
		IF EXISTS(SELECT descripcion FROM productos WHERE descripcion = @descripcion AND productoID <> @productID)
		BEGIN
			RAISERROR('Ya existe un producto con este nombre', 16, 1)
		END
		ELSE IF EXISTS(SELECT barcode FROM productos WHERE (barcode = @barcode AND productoID <> @productID))
		BEGIN
			RAISERROR('Ya existe producto con este codigo, por favor genere uno nuevo',16, 1)
		END
		ELSE IF EXISTS(SELECT descripcion, barcode FROM productos WHERE (descripcion <> @descripcion AND productoID = @productID) OR (barcode <> @barcode AND productoID = @productID))
		BEGIN
			UPDATE [dbo].[productos]
			SET [descripcion] = @descripcion
				,[categoriaID] = @categoriaID
				,[usaInventario] = @usaInventario
				,[stock] = @stock
				,[precioCompra] = @precioCompra
				,[fechaVencimiento] = @fechaVencimiento
				,[precioVenta] = @precioVenta
				,[barcode] = @barcode
				,[tipoVenta] = @tipoVenta
				,[impuesto] = @impuesto
				,[stockMinimo] = @stockMinimo
				,[precioMayoreo] = @precioMayoreo
				,[aPartirDe] = @aPartirDe
			WHERE productoID = @productID
		END
	END

	IF(@accion = 'GenerateBarCode')
	BEGIN
		SELECT MAX(productoID)
		FROM productos
	END

	IF(@accion = 'EliminarProductos')
	BEGIN
		DELETE FROM productos
		WHERE productoID = @productID
	END
END
GO
/****** Object:  StoredProcedure [dbo].[CRUD_USUARIOS]    Script Date: 8/6/2024 22:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CRUD_USERS_FUNCIONA]
    @nombres nvarchar(60) = null,
    @usuario nvarchar(50) = null,
    @password nvarchar(50) = null,
    @icono image = null,
    @nombreIcono nvarchar(max) = null,
    @correo nvarchar(300) = null,
    @rol nvarchar(max) = null,
    @codigo int = null,
    @buscar nvarchar(max) = null,
    @accion nvarchar(50) = null
AS
BEGIN
    BEGIN TRY
        IF (@accion = 'Mostrar')
        BEGIN
            SELECT usuarioID, nombres AS [Nombre Completo], usuario AS Usuario, password AS Contraseña, icono, nombreIcono, correo AS Correo, rol
            FROM usuarios
            WHERE estado = 'Activo'
        END

        IF (@accion = 'Insertar')
        BEGIN
            IF EXISTS (SELECT usuario FROM usuarios WHERE usuario = @usuario AND estado = 'Activo')
            BEGIN
                RAISERROR('El usuario ya existe, Por favor intente de nuevo', 16, 1);
            END
            ELSE
            BEGIN
                BEGIN TRANSACTION
                INSERT INTO usuarios (nombres, usuario, password, icono, nombreIcono, correo, rol, estado)
                VALUES (@nombres, @usuario, @password, @icono, @nombreIcono, @correo, @rol, 'Activo')
                COMMIT TRANSACTION
            END
        END

        IF (@accion = 'Actualizar')
        BEGIN
            IF EXISTS (SELECT usuario FROM usuarios WHERE (usuario = @usuario AND usuarioID <> @codigo AND estado = 'Activo') OR (nombres = @nombres AND usuarioID <> @codigo AND estado = 'Activo'))
            BEGIN
                RAISERROR('El usuario ya existe, Por favor intente de nuevo', 16, 1);
            END
            ELSE
            BEGIN
                BEGIN TRANSACTION
                UPDATE usuarios SET
                    nombres = @nombres,
                    usuario = @usuario,
                    password = @password,
                    icono = @icono,
                    nombreIcono = @nombreIcono,
                    correo = @correo,
                    rol = @rol
                WHERE usuarioID = @codigo
                COMMIT TRANSACTION
            END
        END

        IF (@accion = 'Eliminar')
        BEGIN
            IF EXISTS (SELECT usuario FROM usuarios WHERE usuario = 'Administrador' AND usuarioID = @codigo)
            BEGIN
                RAISERROR('El usuario Administrador no se puede eliminar, si se borra le quitas el acceso al sistema', 16, 1);
            END
            ELSE
            BEGIN
                BEGIN TRANSACTION
                UPDATE usuarios
                SET estado = 'Eliminado'
                WHERE usuarioID = @codigo AND usuario <> 'Administrador'
                COMMIT TRANSACTION
            END
        END

        IF (@accion = 'Buscar')
        BEGIN
            SELECT usuarioID, nombres AS [Nombre Completo], usuario AS Usuario, password AS Contraseña, icono, nombreIcono, correo AS Correo, rol
            FROM usuarios
            WHERE (nombres + usuario + correo) LIKE '%' + @buscar + '%' AND estado = 'Activo'
        END
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION

        DECLARE @ErrorMessage NVARCHAR(4000), @ErrorSeverity INT, @ErrorState INT;
        SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END

GO
/****** Object:  StoredProcedure [dbo].[Design_Tickets]    Script Date: 8/6/2024 22:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Design_Tickets]
@accion NVARCHAR(50) = NULL,
@identificadorFiscal NVARCHAR(MAX) = NULL,
@direccion NVARCHAR(MAX) = NULL,
@provincia NVARCHAR(MAX) = NULL,
@nombreMoneda NVARCHAR(MAX) = NULL,
@agradecimiento NVARCHAR(MAX) = NULL,
@paginaWeb NVARCHAR(MAX) = NULL,
@anuncio NVARCHAR(MAX) = NULL,
@datosFiscales NVARCHAR(MAX) = NULL,
@forDefault NVARCHAR(MAX) = NULL
AS
DECLARE @empresaID INT = (SELECT empresaID FROM empresas);
BEGIN
	IF(@accion = 'Tickets')
	BEGIN
		INSERT INTO tickets
		VALUES (
			@empresaID,
			@identificadorFiscal,
			@direccion,
			@provincia,
			@nombreMoneda,
			@agradecimiento,
			@paginaWeb,
			@anuncio,
			@datosFiscales,
			@forDefault
		)
	END
END
GO
/****** Object:  StoredProcedure [dbo].[EnvioDeCorreos]    Script Date: 8/6/2024 22:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


			CREATE PROCEDURE [dbo].[EnvioDeCorreos]
			@correo nvarchar(max)
			AS
			BEGIN
				SELECT nombres, usuario, password, correo
				FROM usuarios
				WHERE correo = @correo
			END
GO
/****** Object:  StoredProcedure [dbo].[IniciarSesion]    Script Date: 8/6/2024 22:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[IniciarSesion]
@usuario NVARCHAR(50) = null,
@pass nvarchar(50) = null,
@serialPCID NVARCHAR(MAX) = NULL,
@accion nvarchar(50) = null
AS
DECLARE @usuarioID INT;
SET @usuarioID = (SELECT usuarioID FROM usuarios)
BEGIN
	IF(@accion = 'Login')
	BEGIN
		SELECT usuarioID, usuario, password, rol FROM usuarios
		WHERE usuario = @usuario AND password = @pass AND estado = 'Activo'
	END

	IF(@accion = 'Mostrar')
	BEGIN
		SELECT *
		FROM usuarios
	END

	IF(@accion = 'Logins')
	BEGIN
		INSERT INTO logins
		VALUES (
			@serialPCID,
			@usuarioID
		)
	END
END
GO
/****** Object:  StoredProcedure [dbo].[LicenciasSistema]    Script Date: 8/6/2024 22:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[LicenciasSistema]
@accion NVARCHAR(50) = NULL,
@s nvarchar(MAX) = NULL,
@f nvarchar(MAX) = NULL,
@e nvarchar(MAX) = NULL,
@fa nvarchar(MAX) = NULL
AS
BEGIN
	IF(@accion = 'LicenciaPrueba')
	BEGIN
		INSERT INTO licencias
		VALUES (
			@s, @f, @e, @fa
		)
	END
END
GO
/****** Object:  StoredProcedure [dbo].[PROCESOS_CAJAS]    Script Date: 8/6/2024 22:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PROCESOS_CAJAS]
@fechaInicio DATETIME = null,
@fechaFin DATETIME = null,
@fechaCierre DATETIME = null,
@ingresos NUMERIC(18, 2) = null,
@egresos NUMERIC(18, 2) = null,
@saldoRestante NUMERIC(18, 2) = null,
@usuarioID INT = null,
@totalCalculado NUMERIC(18, 2) = null,
@totalReal NUMERIC(18, 2) = null,
@estado NVARCHAR(50) = null,
@diferencia NUMERIC(18, 2) = null,
@cajaID INT = null,

@serial NVARCHAR(50) = null,
@accion NVARCHAR(50) = null
AS
BEGIN
	IF(@accion = 'MostrarCajaSerial')
	BEGIN
		SELECT cajaID, descripcion
		FROM cajas
		WHERE serialPC = @serial
	END

	IF(@accion = 'MovimientosCajasSerial')
	BEGIN
		SELECT B.usuario, B.nombres
		FROM [dbo].[movimientosCierresCajas] A INNER JOIN [dbo].[usuarios] B
			ON
			B.usuarioID = A.usuarioID INNER JOIN [dbo].[cajas] C
			ON
			C.cajaID = A.CajaID
		WHERE C.serialPC = @serial AND A.estado = 'CAJA APERTURADA' AND B.usuarioID = @usuarioID AND B.estado = 'Activo'
	END

	IF(@accion = 'InsertarCierreCaja')
	BEGIN
		IF EXISTS(SELECT estado FROM [dbo].[movimientosCierresCajas] WHERE estado = 'CAJA APERTURADA')
		BEGIN
			RAISERROR('Ya fue aperturado el turno de esta caja', 16, 1);
		END
		ELSE
		BEGIN
			INSERT INTO [dbo].[movimientosCierresCajas]
			VALUES(
					@fechaInicio
				,@fechaFin
				,@fechaCierre
				,@ingresos
				,@egresos
				,@saldoRestante
				,@usuarioID
				,@totalCalculado
				,@totalReal
				,@estado
				,@diferencia
				,@cajaID
			)
		END
	END

	IF(@accion = 'EditarSaldoInicial')
	BEGIN
		UPDATE movimientosCierresCajas SET saldoRestante = @saldoRestante
		WHERE cajaID = @cajaID AND estado = 'CAJA APERTURADA'
	END

	IF(@accion = 'CerrarCaja')
	BEGIN
		UPDATE movimientosCierresCajas 
		SET estado = 'CAJA CERRADA',
			fechaFin = @fechaFin,
			fechaCierre = @fechaCierre
		WHERE cajaID = @cajaID AND estado = 'CAJA APERTURADA'
	END
END


GO
/****** Object:  StoredProcedure [dbo].[sesion]    Script Date: 8/6/2024 22:31:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sesion]
AS
BEGIN
	SELECT usuarioID, usuario FROM usuarios
END
GO
USE [master]
GO
ALTER DATABASE [dbCarwash] SET  READ_WRITE 
GO
";

    }
}