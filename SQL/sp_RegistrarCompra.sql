
create or alter procedure sp_RegistrarCompra(
@tipoDocumento varchar(50),
@idUsuario int,
@idProveedor int,
@subTotal decimal(10,2),
@impuestoTotal decimal(10,2),
@total decimal(10,2),
@productos xml,
@nroDocumento varchar(6) output
)
as
begin
	declare @nrodocgenerado varchar(6)
	declare @nro int
	declare @idCompra int

	declare @tbproductos table (
	IdProducto int,
	Cantidad int,
	Precio decimal(10,2),
	Total decimal(10,2)
	)

	BEGIN TRY
		BEGIN TRANSACTION

			insert into @tbproductos(IdProducto,Cantidad,Precio,Total)
			select 
				nodo.elemento.value('IdProducto[1]','int') as IdProducto,
				nodo.elemento.value('Cantidad[1]','int') as Cantidad,
				nodo.elemento.value('Precio[1]','decimal(10,2)') as Precio,
				nodo.elemento.value('Total[1]','decimal(10,2)') as Total
			from @productos.nodes('Productos/Item') nodo(elemento)

			update NumeroDocumento set
			@nro = id= id+1
			
			set @nrodocgenerado =  RIGHT('000000' + convert(varchar(max),@nro),6)

			insert into Compra(numeroDocumento, tipoDocumento,idUsuario,FechaRegistro,IdProveedor,subTotal,impuestoTotal,total) 
			values (@nrodocgenerado,@tipoDocumento,@idUsuario,getdate(),@idProveedor,@subTotal,@impuestoTotal,@total)


			set @idCompra = SCOPE_IDENTITY()

			insert into DetalleCompras(IdCompra,idProducto,cantidad,precio,total) 
			select @idCompra,IdProducto,Cantidad,Precio,Total from @tbproductos

			--update p set p.Stock = p.Stock - dv.Cantidad from PRODUCTO p
			--inner join @tbproductos dv on dv.IdProducto = p.IdProducto

		COMMIT
		set @nroDocumento = @nrodocgenerado

	END TRY
	BEGIN CATCH
		ROLLBACK
		set @nroDocumento = ''
	END CATCH

end
