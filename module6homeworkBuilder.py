class Report:
    def __init__(self):
        self.header = ""
        self.content = ""
        self.footer = ""
    def __str__(self):
        return f"{self.header}\n{self.content}\n{self.footer}"

class TextReportBuilder:
    def __init__(self):
        self.report = Report()
    def set_header(self, header):
        self.report.header = header
    def set_content(self, content):
        self.report.content = content
    def set_footer(self, footer):
        self.report.footer = footer
    def get_report(self):
        return self.report

class HtmlReportBuilder:
    def __init__(self):
        self.report = Report()
    def set_header(self, header):
        self.report.header = f"<h1>{header}</h1>"
    def set_content(self, content):
        self.report.content = f"<p>{content}</p>"
    def set_footer(self, footer):
        self.report.footer = f"<footer>{footer}</footer>"
    def get_report(self):
        return self.report

class ReportDirector:
    def construct_report(self, builder):
        builder.set_header("заголовок отчета")
        builder.set_content("содержимое отчета")
        builder.set_footer("подвал отчета")
        return builder.get_report()

director = ReportDirector()
text_builder = TextReportBuilder()
text_report = director.construct_report(text_builder)
html_builder = HtmlReportBuilder()
html_report = director.construct_report(html_builder)
print("Текстовый отчет:")
print(text_report)
print("\nHTML отчет:")
print(html_report)
