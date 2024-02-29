using api_opportunities.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace api_opportunities.Models.Opportunities;

public static class OpportunitiesEndpoints
{
    public static void AddEndPoints(WebApplication app)
    {
        var opportR = app.MapGroup("opportunities");
        
        // /opportunities => Get:
        opportR.MapGet("", async (AppDbContext context, CancellationToken ct) =>
        {
            var allOp = await context.AllOpportunities.Select(o => new OpportunityDto(o.Id, o.Title, o.Desc, o.Type, o.Link, o.Money, o.Status.ToString(),o.DateChangesString)).ToListAsync(ct);
            return Results.Ok(allOp);
        });
        
        // /opportunities => Post:
        opportR.MapPost("", async (AddNewOpportunity request, AppDbContext context, CancellationToken ct) =>
        {
            Opportunity newOpportunity;
            if (request.Title.IsNullOrEmpty())
            {
                return Results.BadRequest(new {err=true, msg="Title cannot be empty"});
            }
            
            if (request.Desc.IsNullOrEmpty())
            {
                return Results.BadRequest(new {err=true, msg="Description cannot be empty"});
            }
            
            if (request.Type.IsNullOrEmpty())
            {
                return Results.BadRequest(new {err=true, msg="Type cannot be empty"});
            }
            
            if (request.Link.IsNullOrEmpty())
            {
                return Results.BadRequest(new {err=true, msg="Link cannot be empty"});
            }
            
            newOpportunity =
                new Opportunity(request.Title, request.Desc, request.Type, request.Link, request.Money);

            await context.AllOpportunities.AddAsync(newOpportunity, ct);
            await context.SaveChangesAsync(ct);
            return Results.Ok(new { err = false, msg = "Opportunity added sucessfully", idAdded = newOpportunity.Id });

        });
        
        // /opportunities/{id} => Put:
        opportR.MapPut("{id:guid}", async (Guid id, EditOpportunity request, AppDbContext context, CancellationToken ct) =>
        {
            var opportunityToEdit = await context.AllOpportunities.SingleOrDefaultAsync(o => o.Id == id, ct);

            if (opportunityToEdit == null)
            {
                return Results.NotFound();
            }
            #region Null or Empty Check
            // title:
            if (!string.IsNullOrEmpty(request.Title))
            {
                opportunityToEdit.ChangeTitle(request.Title);
            }
            // desc:
            if (!string.IsNullOrEmpty(request.Desc))
            {
                opportunityToEdit.ChangeDescription(request.Desc);
            }
            // type
            if (!string.IsNullOrEmpty(request.Type))
            {
                opportunityToEdit.ChangeType(request.Type);
            }
            // link
            if (!string.IsNullOrEmpty(request.Link))
            {
                opportunityToEdit.ChangeLink(request.Link);
            }
            // money
            if (request.Money != 0)
            {
                opportunityToEdit.ChangeMoney(request.Money);
            }
            #endregion

            await context.SaveChangesAsync(ct);

            return Results.Ok(new { err = false, msg = "Changed sucessfully", idChanged = opportunityToEdit.Id });

        });
        
        // /opportunities/{id} => Delete:
        opportR.MapDelete("{id:guid}", async (Guid id, AppDbContext context, CancellationToken ct) =>
        {
            var opportunityToDelete = await context.AllOpportunities.SingleOrDefaultAsync(o => o.Id == id, ct);

            if (opportunityToDelete == null)
            {
                return Results.NotFound();
            }

            context.AllOpportunities.Remove(opportunityToDelete);
            await context.SaveChangesAsync(ct);
            return Results.Ok(new
                { err = false, msg = "Opportunity deleted sucessfully", idDeleted = opportunityToDelete.Id });
        });

        #region /opportunities/{StatusOpp}/{id}
        // /opportunities/nassigned/{id} => nassigned{id}
        opportR.MapPut("/naplicado/{id:guid}", async (Guid id, AppDbContext context, CancellationToken ct) =>
        {
            var toChange = await context.AllOpportunities.SingleOrDefaultAsync(o => o.Id == id, ct);
            if (toChange == null) { return Results.NotFound();}

            toChange.NAplicado();
            await context.SaveChangesAsync(ct);
            return Results.Ok(new {err=false, msg="Changed to NotAssigned", idChanged=toChange.Id});
        });
        // /opportunities/assigned/{id} => Assigned{id}
        opportR.MapPut("/aplicado/{id:guid}", async (Guid id, AppDbContext context, CancellationToken ct) =>
        {
            var toChange = await context.AllOpportunities.SingleOrDefaultAsync(o => o.Id == id, ct);
            if (toChange == null) { return Results.NotFound();}

            toChange.Aplicado();
            await context.SaveChangesAsync(ct);
            return Results.Ok(new {err=false, msg="Changed to Assigned", idChanged=toChange.Id});
        });
        // /opportunities/scheduled/{id} => scheduled{id}
        opportR.MapPut("/entmarcada/{id:guid}", async (Guid id, AppDbContext context, CancellationToken ct) =>
        {
            var toChange = await context.AllOpportunities.SingleOrDefaultAsync(o => o.Id == id, ct);
            if (toChange == null) { return Results.NotFound();}

            toChange.EntMarcada();
            await context.SaveChangesAsync(ct);
            return Results.Ok(new {err=false, msg="Changed to Scheduled", idChanged=toChange.Id});
        });
        // /opportunities/approved/{id} => approved{id}
        opportR.MapPut("/aprovado/{id:guid}", async (Guid id, AppDbContext context, CancellationToken ct) =>
        {
            var toChange = await context.AllOpportunities.SingleOrDefaultAsync(o => o.Id == id, ct);
            if (toChange == null) { return Results.NotFound();}

            toChange.Aprovado();
            await context.SaveChangesAsync(ct);
            return Results.Ok(new {err=false, msg="Changed to Approved", idChanged=toChange.Id});
        });
        // /opportunities/disapproved/{id} => disapproved{id}
        opportR.MapPut("/naprovado/{id:guid}", async (Guid id, AppDbContext context, CancellationToken ct) =>
        {
            var toChange = await context.AllOpportunities.SingleOrDefaultAsync(o => o.Id == id, ct);
            if (toChange == null) { return Results.NotFound();}

            toChange.NAprovado();
            await context.SaveChangesAsync(ct);
            return Results.Ok(new {err=false, msg="Changed to Disapproved", idChanged=toChange.Id});
        });
        #endregion
    }
}