SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_Users_Select_ById]
	@idUser INT = NULL
AS
SET NOCOUNT ON;
BEGIN
	BEGIN TRY
		BEGIN
			IF @idUser != 0
				SELECT u.idUser, u.firstName, u.lastName, u.email,
						ur.idRol,
							r.code AS codeRol, r.description AS descriptionRol,
                            r.status AS statusRol, u.status AS statusUser,
                            JSON_QUERY((
                                SELECT p.idPolicy, p.code AS codePolicy,
                                    p.description AS descriptionPolicy, p.route AS routePolicy,
                                    p.status AS statusPolicy
                                    FROM userRol ur
                                        INNER JOIN users u1 ON u1.idUser = ur.idUser
                                        INNER JOIN roles r ON r.idRol = ur.idRol
                                        INNER JOIN rolPolicy rp ON rp.idRol = ur.idRol
                                        INNER JOIN policy p ON p.idPolicy = rp.idPolicy
                                        WHERE u1.idUser = u.idUser
                                FOR JSON PATH
                            )) AS policyUser
						FROM userRol ur
							INNER JOIN users u ON u.idUser = ur.idUser
							INNER JOIN roles r ON r.idRol = ur.idRol
							WHERE u.idUser = @idUser
		END
	END TRY
		BEGIN CATCH
			SELECT ERROR_MESSAGE() AS ERROR,
				ERROR_NUMBER() AS ERROR_NRO
		END CATCH;
END
GO
