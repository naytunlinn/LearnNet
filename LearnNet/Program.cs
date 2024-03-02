using LearnNet.DAO;
using LearnNet.Models.DataModels;
using LearnNet.Models.ViewModels;
using LearnNet.Repositories;
using LearnNet.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

//Configure the appSetting to the database
var connectionString =builder.Configuration.GetConnectionString("LearnNetDB");
builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(connectionString));
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultUI().AddDefaultTokenProviders();

///////////////////////////////// Repository /////////////////////////
builder.Services.AddScoped<IRepository<AssessmentEntity>, AssessmentRepository>();
builder.Services.AddScoped<IRepository<CommentEntity>, CommentRepository>();
builder.Services.AddScoped<IRepository<CourseEntity>, CourseRepository>();
builder.Services.AddScoped<IRepository<DiscussionForumEntity>, DiscussionForumRepository>();
builder.Services.AddScoped<IRepository<EnrollmentEntity>, EnrollmentRepository>();
builder.Services.AddScoped<IRepository<ModuleEntity>, ModuleRepository>();
builder.Services.AddScoped<IRepository<PostEntity>, PostRepository>();
builder.Services.AddScoped<IRepository<ResourceEntity>, ResourceRepository>();
builder.Services.AddScoped<IRepository<SubmissionEntity>, SubmissionRepository>();
builder.Services.AddScoped<IRepository<StudentEntity>, StudentRepository>();
builder.Services.AddScoped<IRepository<VideoEntity>, VideoRepository>();
///////////////////////////////////////////////////////////////////////////

/////////////////////////////////  Service ////////////////////////////////////
builder.Services.AddScoped<IService<AssessmentViewModel>, AssessmentService>();
builder.Services.AddScoped<IService<CommentViewModel>, CommentService>();
builder.Services.AddScoped<IService<CourseViewModel>, CourseService>();
builder.Services.AddScoped<IService<DiscussionForumViewModel>, DiscussionForumService>();
builder.Services.AddScoped<IService<EnrollmentViewModel>, EnrollmentService>();
builder.Services.AddScoped<IService<ModuleViewModel>, ModuleService>();
builder.Services.AddScoped<IService<PostViewModel>, PostService>();
builder.Services.AddScoped<IService<ResourceViewModel>, ResourceService>();
builder.Services.AddScoped<IService<SubmissionViewModel>, SubmissionService>();
builder.Services.AddScoped<IService<StudentViewModel>, StudentService>();
builder.Services.AddScoped<IService<VideoViewModel>, VideoService>();

/////////////////////////////////////////////////////////////

var app = builder.Build();
/////////////////////////////
///

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//enable authentiction & authorization for user management
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();